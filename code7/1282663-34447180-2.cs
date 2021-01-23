    private void InitiateLoad()
    {     
        if (!Directory.Exists(Application.persistentDataPath + "/" + folderPath))
        {
            Debug.Log("Domain Does Not Exsist");
            Directory.CreateDirectory(Application.persistentDataPath + "/" + folderPath);
        }
        if(!File.Exists(URI))
        {            
            SetupLoader();
        }
        else
        {
            long existingFileSize = new FileInfo(path).Length;
            long expectedFileSize = 0;
            string url = "http://myserver.com/" + folderPath + URI;
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(url);
            req.Method = "HEAD";
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                int ContentLength;
                if(int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                { 
                    expectedFileSize = ContentLength;
                }
            }
            if(existingFileSize != expectedFileSize)
            {                
                SetupLoader();
            }
        }
    }
