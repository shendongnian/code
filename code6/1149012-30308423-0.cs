         const string FOLDER = @"c:\temp";
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo(FOLDER);
            FileInfo[] files = info.GetFiles("*.png", SearchOption.TopDirectoryOnly);
            DateTime today = DateTime.Now;
            string[] filteredFiles = files.Where(x => x.LastWriteTime >= today.AddDays(-30)).Select(y => y.FullName).ToArray();
        }
 
