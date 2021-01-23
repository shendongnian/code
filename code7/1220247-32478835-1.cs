      private static void Main(string[] args)
        {
            watch();
            syncAllFilesFirstTime();
            Console.ReadLine();
        }
        private static void syncAllFilesFirstTime()
        {
            //Get list of files from sourcepath
            string[] arrFiles = Directory.GetFiles(strSourcePath);
            foreach (string sourceFiles in arrFiles)
            {
                //get filename
                string strFileName = Path.GetFileName(sourceFiles);
                string strDesFilePath = string.Format(@"{0}\{1}", strDesPath, strFileName);
                //check whether the destination path contatins the same file
                if (!File.Exists(strDesFilePath))
                    File.Copy(sourceFiles, strDesFilePath, true);
            }
        }
        private static void syncUpdatedFiles(string strSourceFile)
        {
            //get filename
            string strFileName = Path.GetFileName(strSourceFile);
            string strDesFilePath = string.Format(@"{0}\{1}", strDesPath, strFileName);
            var val = File.Exists(strDesFilePath);
            //check whether the destination path contatins the same file
            if (!File.Exists(strDesFilePath))
            {
                for (; ;)
                {
                    if (IsFileLocked(strSourceFile))
                    {
                        File.Copy(strSourceFile, strDesFilePath, true);
                        break;
                    }
                }
            }
        }
        private static void watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = strSourcePath;
            //watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "*.*";
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            syncUpdatedFiles(e.FullPath);
        }
       
        public static bool IsFileLocked(string strSourcePath)
        {
            try
            {
                using (Stream stream = new FileStream(strSourcePath, FileMode.Open))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
