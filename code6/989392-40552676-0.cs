    string host="ssgty";
    string username="usr";
    string password="passw";
    int port=22;
    string fromFile=@"D:\Test.txt";
    string toFile=@"/dmon/myfolder/Test.txt";
    
    public string CopyToFTP(string host, string username, string password, int port, string fromFile, string toFile)
    {
          string error = "";
          try
          {
               Scp scp = new Scp(host, username, password);
               scp.Connect(port);
               scp.To(fromFile, toFile);
          }
          catch (Exception ex)
          {
               error = ex.Message;
          }
          return error;
    }
