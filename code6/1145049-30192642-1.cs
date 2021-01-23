    class FileDownloader
    {
        struct parameterObject
        {
            public string url;
            public string savePath;
        }
    
        static void downloadfunction(object data)
        {
            parameterObject obj = (parameterObject)data;
    
            if (File.Exists(obj.savePath))
                return;
    
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile(obj.url, obj.savePath);
            }
        }
    
        public static void downloadfromURL(string url, string savePath)
        {
    
            parameterObject obj = new parameterObject();
            obj.url = url;
            obj.savePath = savePath;
    
            Thread thread = new Thread(FileDownloader.downloadfunction);
            thread.Start(obj);
    
        }
    }
