      public static Player[] fillArray() {
        return File
          .ReadLines(GlobalVariables.filePath)
          .Select(line => line.Split(';')) 
          .Select(items => new Player(items[0], items[1], items[2]) {
             HomeRuns = Int.Parse(items[3], CultureInfo.InvariantCulture),
             RBI = Double.Parse(items[4], CultureInfo.InvariantCulture),
             Batting = Double.Parse(items[5], CultureInfo.InvariantCulture),
          })
          .ToArray(); // usually not necessary, but question requies array 
      }
