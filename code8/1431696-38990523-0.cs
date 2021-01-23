        public static FileInfo[] findFile(String whereToSearch, String searchFor , String mode)
        {
            IEnumerable<FileInfo> files = null;
            if (mode.Equals(""))
                mode = "s";
            
            if (searchFor.Equals(""))
                searchFor = "*";
            if (mode.Equals("r") || mode.Equals("recursive"))
            {
                DirectoryInfo dir = new DirectoryInfo(whereToSearch);
                files = dir.EnumerateFiles(searchFor, searchOption: SearchOption.AllDirectories);
            }
            if (mode.Equals("s") || mode.Equals("specific"))
            {
                DirectoryInfo dir = new DirectoryInfo(whereToSearch);
                files = dir.EnumerateFiles(searchFor, searchOption: SearchOption.TopDirectoryOnly);
            }
            if (files != null) return files.ToArray<FileInfo>();
            else return null;
        }
