    public static void GetSftp(string host, string user, string password, int port, string source, string dest, string remoteDest)
        {
    
            Directory.CreateDirectory(dest);
            var winScpSessionOptions = new SessionOptions
            {
                HostName = host,
                Password = password,
                PortNumber = port,
                UserName = user,
                Protocol = Protocol.Sftp,
                GiveUpSecurityAndAcceptAnySshHostKey = true
            };
    
            var session = new Session();
            session.Open(winScpSessionOptions);
    
            var remoteDirInfo = session.ListDirectory(remoteDest);
            foreach (RemoteFileInfo fileInfo in remoteDirInfo.Files)
            {
                if (fileInfo.Name.Equals(".") || fileInfo.Name.Equals("..")) { continue; }
                Console.WriteLine("{0}", remoteDest + fileInfo.Name);
                try
                {
    
                    var x = remoteDest +"/"+ fileInfo.Name;
                    var y = dest +"\\"+ fileInfo.Name; 
    
                    var result = session.GetFiles(x, y);
    
                    if (!result.IsSuccess)
                    {
                        
                    }
                    else
                    {
                        session.RemoveFiles(remoteDest +"/"+ fileInfo.Name);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
     
            }
    
        }
