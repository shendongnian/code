    using System;
    using System.Net;
    
    class Test
    {
    	static void Main()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Anything");
                client.DownloadFile(
                    "https://api.github.com/repos/nodatime/nodatime/zipball",
                    "nodatime.zip");
            }
        }
    }
