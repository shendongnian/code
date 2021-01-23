    private static string Content(string fileLocation)
    {
     using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fileLocation))
        {
          if (stream == null)
           {
              return string.Empty;
           }
           var streamReader = new StreamReader(stream);
           return streamReader.ReadToEnd();
         }
    }
