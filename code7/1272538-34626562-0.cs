     string user = Environment.UserDomainName + "\\" + Environment.UserName;
        RegistrySecurity regSecurity = new RegistrySecurity();
        
        rs.AddAccessRule(new RegistryAccessRule(user, 
                    RegistryRights.ReadKey | RegistryRights.WriteKey, 
                    InheritanceFlags.None, 
                    PropagationFlags.None, 
                    AccessControlType.Allow));
        
        RegistryKey regKey1 = null;
                try
                {
                    regKey1 = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", 
                        RegistryKeyPermissionCheck.Default, rs);                    
                    regKey1.SetValue("FormSuggest Passwords", "no",RegistryValueKind.String);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\r\nUnable to read key: {0}", ex);
                }
