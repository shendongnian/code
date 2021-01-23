      using System.Globalization; 
      using System.IO;
      using System.Linq
    
      ...
    
      double[] data = File
        .ReadLines(@"C:\MyFile.txt") //TODO: put actual file here
        .Select(line => Double.Parse(line, CultureInfo.InvariantCulture))
        .ToArray();
