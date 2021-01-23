    var keyName = @"SOFTWARE\Microsoft\Silverlight";
                using (var regKey = Registry.LocalMachine.OpenSubKey(keyName))
                {
                    var version = regKey.GetValue("Version");
                    if (version + "" == "5.1.30514.0")
                    {
                        MessageBox.Show("Installed");
                    }
                    else
                    {
                        MessageBox.Show("Uninstalled");
                    }
                    var DisplayName = regKey.GetValue("DisplayName");
                    lsitBox1.Items.Add(version);
                    // lsitBox1.Items.Add(DisplayName);
                }
     
         
