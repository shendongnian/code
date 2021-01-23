    public void AddUserBS(string filePath, string separator, string userBS)
    {
      var reader = new StreamReader(filePath);
      var writer = new StreamReader(filePath + "tmp");
      string line;
      while(null != (line = reader.ReadLine())
      {
         writer.Write(line + separator + userBS);
      }
      reader.Dispose();
      writer.Dispose();
      File.Delete(filePath);
      File.Rename(filePath + "tmp", filePath)
    }
