    PipeSecurity PipeSecurity = new PipeSecurity();            
            PipeAccessRule AccessRule = new PipeAccessRule(@"NT AUTHORITY\NETWORK", PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Deny);
            PipeSecurity.AddAccessRule(AccessRule);
            PipeAccessRule AccessRule2 = new PipeAccessRule(string.Format(@"{0}\{1}", Environment.UserDomainName, Environment.UserName), PipeAccessRights.FullControl, System.Security.AccessControl.AccessControlType.Allow);
            PipeSecurity.AddAccessRule(AccessRule2);
