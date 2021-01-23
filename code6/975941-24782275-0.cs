        public static void Copy()
        {
            string _finalPath;
            var files = System.IO.Directory.GetFiles(@"C:\"); // Here replace C:\ with your directory path.
            foreach (var file in files)             
            {
                var filename = file.Substring(file.LastIndexOf("\\") + 1); // Get the filename from absolute path
                _finalPath = filePath; //it is the destination folder path e.g,C:\Users\Neha\Pictures\11-03-2014
                if (System.IO.Directory.Exists(_finalPath))
                {
                    _finalPath = System.IO.Path.Combine(_finalPath, filename);
                    System.IO.File.Copy(file, _finalPath, true);
                }
            }
        }
