    public static void Compress(FileInfo fileToCompress)
           {
               using (FileStream originalFileStream = fileToCompress.OpenRead())
               {
                  using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                       {
                           using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                           {
                               originalFileStream.CopyTo(compressionStream);
                               Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                                   fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
                           }
                       }
               }
           }
