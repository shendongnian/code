    public static List<string> GetFileList(string Directory)
        {
            List<string> Files = new List<string>();
            
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ServerInfo.Root + Directory));
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            
            request.Credentials = new NetworkCredential(ServerInfo.Username, ServerInfo.Username); // Is this correct?
            // request.Credentials = new NetworkCredential(ServerInfo.Username, ServerInfo.Password); // Or may be this one?
            
            request.UseBinary = false;
            request.UsePassive = true;
            
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string CurrentLine = reader.ReadLine();
            while (!string.IsNullOrEmpty(CurrentLine))
            {
                Files.Add(CurrentLine);
                CurrentLine = reader.ReadLine();
            }
            reader.Close();
            response.Close();
            return Files;
        }
