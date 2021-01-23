    string pathString1 = FullFilePath;
    string sourceFileName = Path.GetFileName(pathString1);
    string foldername = Path.GetDirectoryName(pathString1);
    string pathString = Path.Combine(foldername, "Uploaded");
    if (!System.IO.Directory.Exists(pathString))
    {
        System.IO.Directory.CreateDirectory(pathString);
        string destFile = System.IO.Path.Combine(pathString, sourceFileName);
        File.Copy(pathString1, destFile);
        int itries = 0;
        int maxtries = 30;    //suitable time of retrying
        while (itries++ < maxtries)
        {   
            try 
            {
                File.Delete(pathString1);
                itries = 999999;
            }
            catch (Exception ex)
            {
              if (itries > maxtries) throw ex;  
              Thread.Sleep(1000);
            }       
        }
        //File.Delete(FileName);
    }
