    using System;
    using Renci.SshNet;
    
    namespace SSHconsole
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                //Connection information
                string user = "sshuser";
                string pass = "********";
                string host = "127.0.0.1";
    
                //Set up the SSH connection
                using (var client = new SshClient(host, user, pass))
                {
                    //Start the connection
                    client.Connect();
                    var output = client.RunCommand("echo test");
                    client.Disconnect();
                    Console.WriteLine(output.Result);
                }
            }
        }
    }
