      var folder = new Uri(@"C:\Data");
      var paths = System.IO.Directory.GetFiles(folder.LocalPath, "*.*", System.IO.SearchOption.AllDirectories);
      foreach (var uri in paths.Select(p => new Uri(p)))
      {
        Console.WriteLine(folder.MakeRelativeUri(uri).ToString());
      }
