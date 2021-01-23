    Exception exc = null;
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
                  //how to pass args.Error?
               }
           });
           wc.DownloadFileAsync(new Uri(string.Format("{0}/{1}", Settings1.Default.WebPhotosLocation, Path.GetFileName(f.FullName))), filePath);
           mr.WaitOne();
 
           if (exception != null) throw exception;
    }
