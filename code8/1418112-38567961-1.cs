    if (File.Exists(pathToMyFile))
    {
       try
       {
          myFile = File.ReadAllText(pathToMyFile);
       }
       catch
       {
          // Log exception              
       }
    }
