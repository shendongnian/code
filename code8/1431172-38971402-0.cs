    public static IList<string> ReadFile(string fileName) {
      var target = File
        .ReadLines(fileName)
        .Where(line => line
           .Split(',')
           .Take(2)
           .All(item => !string.IsNullOrEmpty(item)))
        .ToList();
    
      File.WriteAllLines(fileName, target);
    
      return result;
    }
