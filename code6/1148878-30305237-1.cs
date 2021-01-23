    using(var writer = File.CreateText(YOUR_FILE_NAME)))
    {
      ....
      foreach (var line in System.IO.File.ReadLines(filename))
      {
        ...
        //replace xdoc.Save(YOUR_FILE_NAME)
        writer.WriteLine(xdoc.ToString());
      }
    }
