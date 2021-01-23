    public static bool FileSerializer<T>(string filePath, T objectToWrite, out string strError, bool append = false)
    {
      using (Stream fileStream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
      {
        strError = string.Empty;
        try
        {
          var binaryFormatter = new BinaryFormatter();
          binaryFormatter.Serialize(fileStream, objectToWrite);
          return true;
        }
        catch (Exception exc)
        {
          strError = "Binary FileSerializer exception:" + exc;
          return false;
        }
      }
    }
