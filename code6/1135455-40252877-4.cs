        public static List<FileInfo> GetFileInformation()
        {
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            var dirInfo = new DirectoryInfo(path);
            return dirInfo.EnumerateFiles().ToList();
        }
