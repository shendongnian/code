        private void EditAccess(List<string> userlist, string folder)
        {
            foreach (string user in userlist)
            {
                var AccessRule = new FileSystemAccessRule(user, FileSystemRights.FullControl,
                    InheritanceFlags.None,
                    PropagationFlags.NoPropagateInherit,
                    AccessControlType.Allow);
                DirectoryInfo rootFolder = new DirectoryInfo(folder);
                DirectorySecurity rootSec = rootFolder.GetAccessControl(AccessControlSections.Access);
                bool Result;
                rootSec.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);
                InheritanceFlags iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
                AccessRule = new FileSystemAccessRule(user, FileSystemRights.FullControl, iFlags, PropagationFlags.InheritOnly, AccessControlType.Allow);
                rootSec.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);
                rootFolder.SetAccessControl(rootSec);
            }
        }
