    void HandleWebClientException(Exception exc)
    {
        ...
    }
    try  
    {
       ManualResetEvent mr = new ManualResetEvent(false);
       mr.Reset();
       using (WebClient wc = new WebClient())
       {
              wc.DownloadFileCompleted += ((sender, args) =>
              {
                   if (args.Error == null)
                   {
                        File.Move(filePath, Path.ChangeExtension(filePath, ".jpg"));
                        mr.Set();
                   }
                   else
                   {
                      HandleWebClientException(args.Error);
                   }
               });
               wc.DownloadFileAsync(new Uri(string.Format("{0}/{1}", Settings1.Default.WebPhotosLocation, Path.GetFileName(f.FullName))), filePath);
               mr.WaitOne();
        }
    }
    catch (Exception ex)
    {
       HandleWebClientException(ex);
    }
