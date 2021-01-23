    using System.Security.AccessControl;
-
     private void SetFullAccessAttribute(string fileName)
            {
                string path = fileName;
                DirectorySecurity sec = Directory.GetAccessControl(path);
                System.Security.Principal.SecurityIdentifier everyone = new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null);
                sec.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                Directory.SetAccessControl(path, sec);
            }
