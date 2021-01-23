    String path = @"C:\Users\Public\TestFolder\WriteLines2.txt";
    String[] lines = System.IO.File.ReadAllLines(path);
    String[] changedLines = lines.Select(x => string.Format("'{0}'", x)).ToArray();
    System.IO.File.WriteAllLines(path);
  
