    try
      {
         if (!Directory.Exists(FilePath))
          {
              Directory.CreateDirectory(FilePath);
          }
      }
    catch (Exception ex)
     {
         // handle them here
     }
