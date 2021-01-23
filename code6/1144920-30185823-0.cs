    using System;
    using System.IO;
    using System.Security.AccessControl;
    
    namespace MyWpfApplication
    {
    	public class AccessRules
    	{
    		private void SetAccessRuleForCurrentUser()
    		{
    			DirectoryInfo myDirectoryInfo = new DirectoryInfo(@"e:\Folder1");
    			DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
    
    			myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(System.Security.Principal.WindowsIdentity.GetCurrent().Name, FileSystemRights.Read, AccessControlType.Allow));
    
    			myDirectoryInfo.SetAccessControl(myDirectorySecurity);
    		}
    	}
    }
