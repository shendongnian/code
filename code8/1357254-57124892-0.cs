    public static double Percentage {get; set;}
    public static long totalSize { get; set; }
    public static void BeginDecompression(string fullFileName, string fileName)
    {
        try
        {               
            var settings = new Configuration().GetSettings();
            CurrentExtractionName = (Path.GetFileNameWithoutExtension(fileName)); 
          
            StringHelpers.ItemInfo item = StringHelpers.GetItemInfo(fileName);
            string extractPath = settings.EmbyAutoOrganizeFolderPath + "\\" +
                                 (Path.GetFileNameWithoutExtension(fileName));
            Directory.CreateDirectory(extractPath);
            IArchive archive = ArchiveFactory.Open(fullFileName);
            // Calculate the total extraction size.
            totalSize = archive.TotalSize;
            
            Console.WriteLine(totalSize);
            foreach (IArchiveEntry entry in archive.Entries.Where(entry => !entry.IsDirectory))
            {
                archive.EntryExtractionEnd += FileMoveSuccess; 
                archive.CompressedBytesRead += Archive_CompressedBytesRead;
                entry.WriteToDirectory(extractPath, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
      
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    private static void Archive_CompressedBytesRead(object sender, CompressedBytesReadEventArgs e)
    {            
        Percentage = ((double)e.CompressedBytesRead / (double)totalSize) * 100;
        Console.WriteLine(Percentage);
    }
