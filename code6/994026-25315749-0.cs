    var lines = new List<string>();
    using (StreamReader streamReader = new StreamReader("file.txt"))
    {
      var line = streamReader.ReadToEnd();
      lines.Add(line); 
    }
      foreach(var lineToSplit in lines)
      {
          string[] split = lineToSplit.Split(',');
          foreach (string element in split)
             {
                var curElement = element.Trim(new Char[] { ' ', '\t' });
                Console.WriteLine(curElement);
             }
      }
