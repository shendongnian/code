    static void Main()
    {
    	// allow more connections at a time
    	ServicePointManager.DefaultConnectionLimit = 30;
    	// don't wait the 100ms every request do
    	ServicePointManager.Expect100Continue = false;
    	
    	for (int i = 0; i <= 200; i++)
    	{
    		var lines = File.ReadAllLines(@"D:\file_" + i.ToString().PadLeft(5, '0') + ".txt");
    		foreach (var line in lines)
    		{
    			Task.Run(() =>
    				{
    					try
    					{
    						WebRequest request = WebRequest.Create("ftp://myftp/dir/" + line);
    						request.Method = WebRequestMethods.Ftp.MakeDirectory;
    						request.Credentials = new NetworkCredential("user", "pass");
    						request.GetResponse();
    					}
    					catch (Exception ex)
    					{ }
    				}
    			);
    		}
    	}
    }
