    string contentToWrite=string.Format("{0}, {1}", DateTime.Now.ToString("HH:mm:ss.ffff")), message);
    public Log(string path)
        {
            this.path = path;
            if(!File.Exists(path))
            {
                File.Create(path);
            }
           File.AppendAllText(path, contentToWrite);
       }
