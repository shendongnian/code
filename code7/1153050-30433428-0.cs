    var finished = false;
    while (!finished)
    {
      try
      {
        if (!File.Exists(locationFile))
        {
          string file = @"mypathtoxml";
          XmlDocument objXmlDoc = new XmlDocument();
          doc.Load(file); 
          finished = true;
        }
      }
      catch (IOException)
      {
        // the file is unavailable because it is:
        // - still being written to
        // - being processed by another thread
        // so we just wait a second
        Thread.Sleep(1000);
      }
    }
