    //assuming this is the new order of columns you want
      int[] positionArray = {2, 1, 0};
      string[] lines = System.IO.File.ReadAllLines(@"c:\temp\testcsv.csv");
      var newLines = lines.Select(p =>
      {
        var columns = p.Split(',');
        var sb = new StringBuilder();
        foreach (var i in positionArray)
        {
          if (sb.Length > 0)
          {
            sb.Append(",");
          }
          sb.Append(columns[i]);
        }
        return sb.ToString();
      }).ToArray();
      System.IO.File.WriteAllLines(@"c:\temp\testcsv2.csv", newLines);
      Console.WriteLine("Spreadsheet2.csv written to disk. Press any key to exit");
      Console.ReadKey(); 
