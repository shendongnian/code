        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://abc.xyz.com/ContractorDoc");
        ftpRequest.Credentials =new NetworkCredential("uname","password");
        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
        FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
        StreamReader streamReader = new StreamReader(response.GetResponseStream());
        
        List<string> directories = new List<string>();
        
        string line = streamReader.ReadLine();
        while (!string.IsNullOrEmpty(line))
        {
            directories.Add(line);
            line = streamReader.ReadLine();
        }
        
        streamReader.Close();
