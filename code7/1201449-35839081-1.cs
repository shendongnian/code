    using (var sshclient = new SshClient(ConnNfo))
                    {
                        
                        sshclient.Connect();
                        using (var cmd = sshclient.CreateCommand(cmdCommand))
                        {
    
                            cmd.Execute();
                            Console.WriteLine("Command>" + cmd.CommandText);
                            Console.WriteLine(cmd.Result);
                            Console.WriteLine("Return Value = {0}", cmd.ExitStatus);
                        }
                        sshclient.Disconnect();
                    }
