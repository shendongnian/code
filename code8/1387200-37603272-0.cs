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
                        bitLockerCheckInvis.Text += string.Format("ProtectionStatus: {0}", queryObj["ProtectionStatus"]);
                        //bitLockerCheck.Text = queryObj["ProtectionStatus"] == "1" ? "Bitlocker Disabled" : "Bitlocker Enabled";
                        // if ((string)queryObj["ProtectionStatus"] == "0") { bitLockerCheck.Text = "Bitlocker Disabled"; }
                        //else if ((string)queryObj["ProtectionStatus"] == "1") { bitLockerCheck.Text = "Bitlocker Enabled"; }
                        // else { bitLockerCheck.Text = ""; }
                    }
                }
                catch (ManagementException)
                {
                    MessageBox.Show("Please Restart the program to check Administrative Settings");
                }
                {
                    if (bitLockerCheckInvis.Text == "ProtectionStatus: 1") { bitLockerCheck.Text += "Bitlocker Enabled"; }
                    if (bitLockerCheckInvis.Text == "ProtectionStatus: 0") { bitLockerCheck.Text += "Bitlocker Disabled"; }
                    if (bitLockerCheckInvis.Text == "ProtectionStatus:  ") { bitLockerCheck.Text += "Bitlocker Not Available"; }
