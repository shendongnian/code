    string[] allLines = File.ReadAllLines(@"d:\test.txt");
    using (StreamWriter sw = new StreamWriter(@"d:\test.txt"))
    {
        foreach (string line in allLines)
        {
            if (!string.IsNullOrEmpty(line) && line.Length > 1)
            {
                sw.WriteLine(Regex.Replace(line,@"\s+",";"));
            }
        }
    }
    MessageBox.Show("ok");
