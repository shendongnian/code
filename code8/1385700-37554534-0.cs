    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Management;
    using System.Windows.Forms;
    namespace ComplianceCheck_2._0
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void Main()
        {
        }
        private void SystemCheck_Click(object sender, System.EventArgs e)
        {
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2\\Security\\MicrosoftVolumeEncryption",
                    "SELECT * FROM Win32_EncryptableVolume");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_EncryptableVolume instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("ProtectionStatus: {0}", queryObj["ProtectionStatus"]);
                    Bitlocker.Text = queryObj["ProtectionStatus"] == "0" ? "False" : "True";
                }
            }
            catch (ManagementException)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " );
            }
        }
    }
    }
