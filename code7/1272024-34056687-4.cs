    private void CheckGarbageCharacters(string filename)
    {
        var lines = File.ReadAllLines(input).ToList();
        for (int i = 0; i < lines.Count; i++)
        {
             var line = lines[i];
             for (int j = 0; j < line.Length; j++)
             {
                  var c = line[j];
                  if (c > '\u007F')
                  {
                       // Grab the next 30 characters after 'c'
                       var text = c.ToString()
                       for (int k = 0; k < 30; k++)
                       {
                            if ((j + k) > (line.Length - 1))
                            {
                                 break;
                            }
                            text += line[j + k].ToString();
                       }
                       // Create the error message
                       var error = new ErrorModel()
                       {
                            Filename = Path.GetFileName(filename),
                            LineNumber = i,
                            ErrorMessage = "Garbage character found.",
                            Text = text
                       };
                       // Add the error to the list
                       _errorList.Add(error);
                  }
             }
        }
    }
