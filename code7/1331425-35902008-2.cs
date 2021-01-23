    List<string> lines = new List<string>();
    foreach (string ss in fileLines)
    {
       string filelinesclean = System.Text.RegularExpressions.Regex.Replace(ss, @"\s+", " ");
       lines.Add(filelinesclean);
    }
    System.IO.File.WriteAllLines(@"C:\Users\Public\WriteLines.txt", lines);
