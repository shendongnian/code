    using(var writer = XmlWriter.Create(YOUR_FILE_NAME)))
    {
      ....
      foreach (var line in System.IO.File.ReadLines(filename))
      {
        ...
        //replace xdoc.Save(YOUR_FILE_NAME)
        xdoc.Save(writer)
      }
    }
