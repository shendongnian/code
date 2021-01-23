    public void SaveFile(Stream fileStream, string filename)
    {
          try
          {
              using (var newFile = File.Create(@"\\NetworkPath\" + filename))
              {
                  fileStream.CopyTo(newFile);
    
                  fileStream.Close();
                  fileStream.Dispose;
              }
          }
          catch (Exception ex)
          {
              //Log if something goes wrong
              LogException(ex);
          }
    }
