    public static IList<string> ReadFile(string fileName)
    {
      var results = new List<string>();
      string[] target = File.ReadAllLines(fileName);
      foreach (string line in target)
      {
        var array = line.Split(','); //If your csv is seperated by ; then replace the , with a ;
        if (!string.IsNullOrWhiteSpace(array[0]) && !string.IsNullOrWhiteSpace(array[1]) && array.Length >= 2)
        results.Add(line);
      }
    return results;
    }
