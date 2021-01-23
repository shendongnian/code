        public Log(string path)
        {
            this.path = path;
            if(!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public void tWrite(Levels levels, string message)
        {
           string contentToWrite=string.Format("{0}, {1}", DateTime.Now.ToString("HH:mm:ss.ffff")), message);
           File.AppendAllText(path, contentToWrite);
        }
   
