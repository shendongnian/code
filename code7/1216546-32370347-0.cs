    [STAThread]
    static void Main(string[] args)
    {
        FtpConnection ftpConn = FtpConnection.Create("risc.ua.edu", 21, 
          Console.Out, Console.Out);
        
        //get directory listing
        DirectoryList dirList = new PassiveDirectoryList(ftpConn);
        byte[] data = dirList.GetList(null, Console.Out, Console.Out);
        
        //parse directory listing
        string list = System.Text.Encoding.ASCII.GetString(data);
        UnixFileNode[] fileNodes = (UnixFileNode[]) new UnixFileNode().FromFtpList(list, 
          ftpConn.CurrentWorkingDirectory);
        
        //show listing on console
        foreach(UnixFileNode fileNode in fileNodes)
        Console.WriteLine(fileNode);
        
        //disconnect
        ftpConn.Close();
    }
