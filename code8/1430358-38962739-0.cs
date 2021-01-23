    private static bool justHadByteUpdate = false;
    public static void ExtractProgress(object sender, ExtractProgressEventArgs e)
    {
      if(e.EventType == ZipProgressEventType.Extracting_EntryBytesWritten)
      {
        if (justHadByteUpdate)
          Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write("   {0}/{1} ({2:N0}%)", e.BytesTransferred, e.TotalBytesToTransfer,
                  e.BytesTransferred / (0.01 * e.TotalBytesToTransfer ));
        justHadByteUpdate = true;
      }
      else if(e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry)
      {
        if (justHadByteUpdate)
          Console.WriteLine();
        Console.WriteLine("Extracting: {0}", e.CurrentEntry.FileName);
        justHadByteUpdate= false;
      }
    }
    public static ExtractZip(string zipToExtract, string directory)
    {
      string TargetDirectory= "extract";
      using (var zip = ZipFile.Read(zipToExtract)) {
        zip.ExtractProgress += ExtractProgress;
        foreach (var e in zip1)
        {
          e.Extract(TargetDirectory, true);
        }
      }
    }
