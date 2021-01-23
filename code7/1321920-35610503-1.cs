    MemoryStream ms = new MemoryStream();
    bool success;
    try
    {    
        if(File.Exists(zipFileName))
        {
            using (FileStream file = new FileStream(zipFileName, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                ms.Write(bytes, 0, (int)file.Length);
            }
   
    
            // unzip the files
            using (ZipFile loZip = ZipFile.Read(ms))
            {
                // Add this line to fix an issue with the DLL
                // http://dotnetzip.codeplex.com/workitem/14087
                loZip.ParallelDeflateThreshold = -1;
                loZip.ExtractAll(extractionPath, ExtractExistingFileAction.OverwriteSilently);
            }
          success = true;
        }
        else
        {
          lsResult = "ZipFile Not Found";
          success = false;
        }
     }
    catch (Exception ex)
    {
          success = false;
        lsResult = "Stream reading crashed. " + ex.Message + Environment.NewLine + Environment.NewLine + ex.InnerException + Environment.NewLine +     Environment.NewLine + ex.StackTrace + Environment.NewLine + Environment.NewLine;
    }
