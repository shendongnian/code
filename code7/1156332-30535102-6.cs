    Exception exc = null;
    using (WebClient wc = new WebClient())
    {
          wc.DownloadFileCompleted += ((sender, args) =>
          ...
          
          mr.WaitOne();
 
          if (exception != null) throw exception;
    }
