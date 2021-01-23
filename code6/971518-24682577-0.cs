                ArrayList groupPolicies = new ArrayList();
            using (RegistryKey historyKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Group Policy\History"))
            {
                foreach (string historySubkey in historyKey.GetSubKeyNames())
                {
                    using (RegistryKey guidKey = historyKey.OpenSubKey(historySubkey))
                    {
                        foreach (string guidsubkey in guidKey.GetSubKeyNames())
                        {
                            using (RegistryKey keyvalue = guidKey.OpenSubKey(guidsubkey))
                            {
                                groupPolicies.Add(keyvalue.GetValue("DisplayName"));
                                //Console.WriteLine(keyvalue.GetValue("DisplayName"));
                            }
                        }
                    }
                }
            }
            if (!groupPolicies.Contains("replacewithyourGPOname"))
            {
                Console.WriteLine("The machine is not a member of the policy");
            }
