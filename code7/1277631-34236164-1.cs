        public void DisplayLastTakenPhoto()
        {
            var directory = new DirectoryInfo(@"C:\temp");
            var myFile = directory.EnumerateFiles()
             .Where(f => f.Extension.Equals(".js", StringComparison.CurrentCultureIgnoreCase) || f.Extension.Equals("raw", StringComparison.CurrentCultureIgnoreCase))
             .OrderByDescending(f => f.LastWriteTime)
             .First();
            Assert.IsNotNull(myFile);
        }
