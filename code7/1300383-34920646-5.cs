    //Code for Program.cs demonstrating the identity impersonation for a ServiceController.
    
    using System;
    using System.Security.Principal;
    using System.ServiceProcess;
    
    namespace RemoteConnectionTest
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    	
    			//Based on the code from http://michiel.vanotegem.nl/2006/07/windowsimpersonationcontext-made-easy/
    
    			Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
    			//Also worked with the IP address of GARNET
    			WrapperImpersonationContext context = new WrapperImpersonationContext("GARNET", "TestAdmin", "password123");
    			context.Enter();
    			// Execute code under other uses context
    			Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
    
    			// Code to execute.
    
    			//Try running the following command on the remote server first to ensure
    			//the user has the appropriate access (obviously substitute the
    			//username and machine name).
    			// runas /user:TestAdmin "sc \\GARNET stop W3SVC"
    
    			//Also, make sure the user on the remote server has access for
    			//services granted as described here: http://stackoverflow.com/a/5084563/201648
    			//Otherwise you may see an error along the lines of:
    			//Cannot open W3SVC service on computer '<SERVER>'. ---> System.ComponentModel.Win32Exception: Access is denied
    			//For my configuration I had to run the command:
    			// SUBINACL /SERVICE \\GARNET\W3SVC /GRANT=GARNET\TestAdmin=TO
    			//It's entirely possible that running this command will allow your existing code to work without using impersonation.
    
    			//You may need to install SUBINACL https://www.microsoft.com/en-au/download/details.aspx?id=23510
    			//By default SUBINACL will install to C:\Program Files (x86)\Windows Resource Kits\Tools
    			//so CD to that directory and then run the SUBINACL command above.
    
    			//Also worked with the IP address of GARNET
    			var sc = new ServiceController("W3SVC", "GARNET");
    			sc.Start();
    
    			sc.WaitForStatus(ServiceControllerStatus.Running);            
    			sc.Stop();
    			sc.WaitForStatus(ServiceControllerStatus.Stopped);
    
    			//END - code to execute.
    			context.Leave();
    			Console.WriteLine("Current user: " + WindowsIdentity.GetCurrent().Name);
    
    			Console.ReadLine();
    
    		}
    	}
    
    }
