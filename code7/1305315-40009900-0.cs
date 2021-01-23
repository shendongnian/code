    if (Directory.Exists(myPath))
      {
      Directory.Delete(myPath, true);
      while (Directory.Exists(myPath))
        System.Threading.Thread.Sleep(10);
      }
    Directory.CreateDirectory(myPath);
