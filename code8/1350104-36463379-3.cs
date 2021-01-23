        static void Main(string[] args)
        {
            try
            {
                // Make a reference to a directory.
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                var fiArr = GetAllFilesRecursive(path);
                // Display the names and sizes of the files.
                Console.WriteLine("The directory {0} contains the following files:", path);
                long size = 0;
                foreach (FileInfo f in fiArr)
                {
                    size += f.Length;
                    size++;
                }
                Console.WriteLine("The size of desktop files." + size);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceptions {0}", e);
            }
        }  
