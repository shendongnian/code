    public class FileName : IComparable<FileName>
    {
        public string fName { get; set; }
        public int CompareTo(FileName other)
        {
            return fName.CompareTo(other.fName);
        }
    }
    public static void getFileList(string sourceURI, string sourceUser, string sourcePass, List<FileName> sourceFileList)
    {
    	string line = "";
    	FtpWebRequest sourceRequest;
    	sourceRequest = (FtpWebRequest)WebRequest.Create(sourceURI);
    	sourceRequest.Credentials = new NetworkCredential(sourceUser, sourcePass);
    	sourceRequest.Method = WebRequestMethods.Ftp.ListDirectory;
    	sourceRequest.UseBinary = true;
    	sourceRequest.KeepAlive = false;
    	sourceRequest.Timeout = -1;
    	sourceRequest.UsePassive = true;
    	FtpWebResponse sourceRespone = (FtpWebResponse)sourceRequest.GetResponse();
    	//Creates a list(fileList) of the file names
    	using (Stream responseStream = sourceRespone.GetResponseStream())
    	{
    		using (StreamReader reader = new StreamReader(responseStream))
    		{
    			line = reader.ReadLine();
    			while (line != null)
    			{
    				var fileName = new FileName
    						{
    							fName = line
    						};
    						sourceFileList.Add(fileName);
    				line = reader.ReadLine();
    			}
    		}
    	}	
    }
