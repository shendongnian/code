    var directory = @"D:\Downloads";
    var extension = @"*.txt";
    var textToSearch = @"abc";
    var files = Directory.GetFiles(directory, extension, SearchOption.AllDirectories);
    ...
    private static List<string> SearchFiles(string directory, string extension, string textToSearch)
    {
      var results = new List<string>();
      var files = Directory.GetFiles(directory, extension, SearchOption.AllDirectories);
      foreach (var file in files)
      {
        var content = File.ReadAllText(file);
        if (content.Contains(textToSearch))
        {
          results.Add(file);
        }
      }
      return results;
    }
