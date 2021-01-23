    private void CheckGarbageCharacters(string filename)
    {
        var lines = File.ReadAllLines(input).ToList();
        for (int i = 0; i < lines.Count; i++)
        {
             var line = lines[i];
             for (int j = 0; j < line.Length; j++)
             {
                  var c = line[j];
                  if (c > '\007F')
                  {
                       var error = new ErrorModel()
                       {
                            Filename = Path.GetFileName(filename),
                            LineNumber = i,
                            ErrorMessage = "Garbage character found.",
                            Text = c.ToString()
                       };
                       _errorList.Add(error);
                  }
             }
        }
    }
