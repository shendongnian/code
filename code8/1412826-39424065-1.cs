    [WebMethod]
            public static string ProcessIT(string downloadURL, string file_name)
            {            
                // Create a new WebClient instance.
                WebClient myWebClient = new WebClient();
                string  path = @"c:\";
                string path_n_name = path + file_name; 
                // Download the Web resource and save it into the current filesystem folder.
                myWebClient.DownloadFile(downloadURL, path_n_name);
                return "SUCCESS";
            }
