    string appPATH = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(appPATH))
                {
                    foreach (string skName in rk.GetSubKeyNames())
                    {
                        using (RegistryKey sk = rk.OpenSubKey(skName))
                        {
                            try
                            {
                               
                                //Get App Name
                                var displayName = sk.GetValue("DisplayName");
                                //Get App Size
                                var size = sk.GetValue("EstimatedSize");
    
                                string item;
                                if (displayName != null)
                                {
                                    if (size != null)
                                        item = displayName.ToString();
                                    else
                                    {
                                        item = displayName.ToString();
                                        if (item.Contains(""))
                                        MessageBox.Show(displayName.ToString());
                                        
                                    }
                                   
                                }
                            }
                            catch (Exception ex)
                            { }
                        }
                    }
                   
                }
