using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RyanSerialChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // disks
            ProcessStartInfo startcmd = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c wmic diskdrive get serialnumber",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startcmd })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                guna2TextBox1.Text = (output.Remove(0, 12).Trim());

            }

            // motherboard
            ProcessStartInfo startcmd2 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c wmic baseboard get serialnumber",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process2 = new Process { StartInfo = startcmd2 })
            {
                process2.Start();
                string output = process2.StandardOutput.ReadToEnd();
                process2.WaitForExit();
                guna2TextBox2.Text = (output.Remove(0, 12).Trim());

            }

            // bios
            ProcessStartInfo startcmd3 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c wmic csproduct get uuid",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process3 = new Process { StartInfo = startcmd3 })
            {
                process3.Start();
                string output = process3.StandardOutput.ReadToEnd();
                process3.WaitForExit();
                guna2TextBox3.Text = (output.Remove(0, 4).Trim());

            }

            // cpu
            ProcessStartInfo startcmd4 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c wmic cpu get processorid",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process4 = new Process { StartInfo = startcmd4 })
            {
                process4.Start();
                string output = process4.StandardOutput.ReadToEnd();
                process4.WaitForExit();
                guna2TextBox4.Text = (output.Remove(0, 11).Trim());

            }

            // mac
            ProcessStartInfo startcmd5 = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c wmic path Win32_NetworkAdapter where \"PNPDeviceID like '%%PCI%%' AND NetConnectionStatus=2 AND AdapterTypeID='0'\" get MacAddress",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process5 = new Process { StartInfo = startcmd5 })
            {
                process5.Start();
                string output = process5.StandardOutput.ReadToEnd();
                process5.WaitForExit();
                if (output.Contains("MACAddress"))
                {
                    guna2TextBox5.Text = (output.Remove(0, 12).Trim());
                }
                else
                {
                    guna2TextBox5.Text = "No MAC Address Found";
                }


            }
            timer1.Stop();
        }
    

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
