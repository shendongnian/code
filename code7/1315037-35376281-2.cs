            using (RegistryKey root = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
            {
                string searchKey = @"Microsoft SQL Server 2012";
                string subKeyName = "DisplayName";
                foreach (string keyname in root.GetSubKeyNames())
                {
                    //Console.WriteLine(keyname);
                    using (RegistryKey key = root.OpenSubKey(keyname))
                    {
                        try  // in case "DisplayName doesn't exist
                        {
                            string displayName = key.GetValue(subKeyName).ToString();
                            if (displayName.StartsWith(searchKey))
                                Console.WriteLine("GUID: " + keyname + Environment.NewLine + displayName + Environment.NewLine);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            Console.ReadLine();
