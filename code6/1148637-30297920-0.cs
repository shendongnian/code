    public static int GetFileCount(DirectoryInfo filePath)
        {
            int requestCount = 0;
    DirectoryInfo info = new DirectoryInfo(filePath);
            DateTime minDate = Convert.ToDateTime(DateTime.Now.AddDays(day).ToShortDateString());
            DateTime maxDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime lastWriteTime = DateTime.MinValue;
    
    requestCount = info.GetFiles().Select(x => (x.LastWriteTime >= minDate  && x.LastWriteTime <= maxDate)).Count();
            
    
            return requestCount;
        }
