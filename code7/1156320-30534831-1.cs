    try  
    {
      
       using (WebClient wc = new WebClient())
       {
              
             await  wc.DownloadFileTaskAsync(new Uri(string.Format("{0}/{1}", Settings1.Default.WebPhotosLocation, Path.GetFileName(f.FullName))), filePath);
             
        }
    }
    catch (Exception ex)
    {
       //Catch my error here and handle it (display message box)
    }
