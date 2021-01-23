    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.AccessControl;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                CreateDirectory(@"C:\TestDirectory", @"IIS_IUSRS");
            }
            public static void CreateDirectory(string DirectoryName, string UserAccount)
            {
                if (!System.IO.Directory.Exists(DirectoryName)) Directory.CreateDirectory(DirectoryName);
                AddUsersAndPermissions(DirectoryName, UserAccount, FileSystemRights.FullControl, AccessControlType.Allow);
            }
            public static void AddUsersAndPermissions(string DirectoryName, string UserAccount, FileSystemRights UserRights, AccessControlType AccessType)
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(DirectoryName);
                    DirectorySecurity dirSecurity = directoryInfo.GetAccessControl();
                    dirSecurity.AddAccessRule(new FileSystemAccessRule(UserAccount, UserRights, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessType));
                    directoryInfo.SetAccessControl(dirSecurity);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
