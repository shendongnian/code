     public string Get(string url,string fileNumber)
        {
            var urlInCurrDomain = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Documents", Path.GetFileNameWithoutExtension(url) +"-" + fileNumber + Path.GetExtension(url));
            if (File.Exists(urlInCurrDomain))
            {
                urlInCurrDomain = TomerUtils.AddSuffix(urlInCurrDomain, 1);
            }
            File.Copy(url, urlInCurrDomain);
            return Path.GetFileName(urlInCurrDomain);
        }
      
        public void Delete(string fileName)
        {
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Documents", fileName);
            if (File.Exists(path))
                File.Delete(path);
        }
