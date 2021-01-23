    using System;
    
    using Renci.SshNet; 
    using System.IO;
    namespace testssh
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var privkey=new PrivateKeyFile (new FileStream ("/home/ukeller/.ssh/id_rsa", FileMode.Open));
    			var authmethod=new PrivateKeyAuthenticationMethod ("ukeller", new PrivateKeyFile[] { privkey});
    			var connectionInfo = new ConnectionInfo("localhost", "ukeller", new AuthenticationMethod[]{authmethod});
    			var remotePath = "/etc/passwd";
    			using (var ssh = new SshClient(connectionInfo))
    			{    
    				ssh.Connect();
    				// Birth, depending on your Linux/unix variant, prints '-' on mine
    				// string comm = "stat -c %w " + @"/" + remotePath;
    
    				// modification time
    				string comm = "stat -c %y " + @"/" + remotePath;
    				var cmd = ssh.RunCommand(comm);
    				var output = cmd.Result;
    				Console.Out.WriteLine (output);
    			}
    		}
    	}
    }
