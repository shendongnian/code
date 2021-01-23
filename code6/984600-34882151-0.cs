    public void Compressfile()
            {
                 string fileName = "Text.txt";
                 string sourcePath = @"C:\SMSDBBACKUP";
                 DirectoryInfo di = new DirectoryInfo(sourcePath);
                 foreach (FileInfo fi in di.GetFiles())
                 {
                     //for specific file 
                     if (fi.ToString() == fileName)
                     {
                         Compress(fi);
                     }
                 } 
            }
    
    public static void Compress(FileInfo fi)
            {
                // Get the stream of the source file.
                using (FileStream inFile = fi.OpenRead())
                {
                    // Prevent compressing hidden and 
                    // already compressed files.
                    if ((File.GetAttributes(fi.FullName)
                        & FileAttributes.Hidden)
                        != FileAttributes.Hidden & fi.Extension != ".gz")
                    {
                        // Create the compressed file.
                        using (FileStream outFile =
                                    File.Create(fi.FullName + ".gz"))
                        {
                            using (GZipStream Compress =
                                new GZipStream(outFile,
                                CompressionMode.Compress))
                            {
                                // Copy the source file into 
                                // the compression stream.
                                inFile.CopyTo(Compress);
    
                                Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                    fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                            }
                        }
                    }
                }
            }
    
        }
