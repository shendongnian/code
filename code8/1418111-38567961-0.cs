    if (File.Exists(pathToMyFile))
    {
       try
       {
          using (var fs = new FileStream(pathToMyFile, FileMode.Open, FileAccess.Read))
          {
             BinaryReader br = new BinaryReader(fs);
             Byte[] bytes = br.ReadBytes((Int32) fs.Length);
             br.Close();
             fs.Close();
             myFile = Convert.ToBase64String(bytes);
          }
       }
       catch
       {
          // Log exception
       }
    }
