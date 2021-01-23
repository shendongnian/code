    string[] path = @"C:\Users\Public\TestFolder\WriteLines2.txt";
    string[] lines = System.IO.File.ReadAllLines(path);
    // change every line
    for (int index = 0; index < lines.Length; ++index)
    {         
        lines[index] = string.Format("'{0}',", lines[index]);
    }
    System.IO.File.WriteAllLines(path, lines);
  
