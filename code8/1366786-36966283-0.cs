    int elementId  = await Task.Factory.StartNew(() => 
    {
      try
      {
        using (Source.Token.Register(Thread.CurrentThread.Interrupt))
        {
          return Uploader.Upload(endpoint, objectToBeUploaded));
        }
      }
      catch (ThreadInterruptedException ex)
      {
         throw new OperationCanceledEception(ex)
      }
    }, Source.Token);
