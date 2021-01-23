    String path = @"C:\Users\Public\TestFolder\WriteLines2.txt";
    String[] lines = System.IO.File.ReadAllLines(path);
    //I'm using System.Linq to change the lines. I'm adding a "'" before and after the original token.
    String[] changedLines = lines.Select(x => string.Format("'{0}',", x)).ToArray();
    // I'm saving the changes to the file.
    System.IO.File.WriteAllLines(path, changedLines);
