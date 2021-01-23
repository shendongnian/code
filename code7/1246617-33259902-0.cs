     if (File.Exists("FileName")
     {
         FileInfo fi = new FileInfo(args[0]);
         touchFile(fi);
     }
    static void touchFile(FileSystemInfo fsi)
            {
                Console.WriteLine("Touching: {0}", fsi.FullName);
    
                // Update the CreationTime, LastWriteTime and LastAccessTime.
                try
                {
                    // Set or Get Creation ,LastWriteTime ,LastAccessTime
                    fsi.CreationTime = fsi.LastWriteTime = fsi.LastAccessTime =
                        DateTime.Now;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }
