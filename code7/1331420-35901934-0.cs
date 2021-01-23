    var lines = new List<string>();
    foreach (string ss in fileLines)
    {
        lines.Add(Regex.Replace(ss, @"\s+", " "));
    }
    MessageBox.Show("ok");
    File.WriteAllLines(@"C:\Users\Public\WriteLines.txt", lines);
