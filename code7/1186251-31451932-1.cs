    Dictionary<string, string> members = new Dictionary<string, string>();
    
    String lineToFind = "testString";
    
    // Let's read the file up in order to avoid read/write conflicts
    var data = File
      .ReadLines(pathToFile)
      .ToList();
    
    var before = data
      .TakeWhile(line => line != lineToFind)
      .Concat(new String[] {lineToFind}); // add lineToFind
    
    var after = data
      .SkipWhile(line => line != lineToFind)
      .Skip(1); // skip lineToFind
    
    var stuff = members
      .Select(entry => String.Format("[{0} {1}]", entry.Key, entry.Value));
    
    File.WriteAllLines(pathToFile, before
      .Concat(stuff)
      .Concat(after));
