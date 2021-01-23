    // Read your file using File.ReadAllLines
    String[] lines = new[] { "L1 G2 X50 Y50", "L1 G2 X50 Y50" };
    foreach (var line in lines)
    {
         String[] values = line.Split(' ');
         string x = values.Where(s => s.StartsWith("X")).First().Replace("X", String.Empty);            
         int xCoordinate = Convert.ToInt32(x);            
    }
