    var lines = new List<string>();
      lines.AddRange(File.ReadAllLines(@"test.txt"));
      foreach(var lineToSplit in lines)
      {
          string[] split = lineToSplit.Split(',');
          foreach (string element in split)
             {
                var curElement = element.Trim(new Char[] { ' ', '\t' });
                Console.WriteLine(curElement);
             }
      }
