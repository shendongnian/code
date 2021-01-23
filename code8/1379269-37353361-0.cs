    ContinueWith(async task => 
    {    
        using (var streamWriter = new StreamWriter(File, true))
        {
           using (var textWriter = TextWriter.Synchronized(streamWriter))
           {
               textWriter.WriteLine(base.RenderLoggingEvent(loggingEvent));
               await textWriter.FlushAsync();
            }
         }
    }, TaskContinuationOptions.OnlyOnFaulted);
