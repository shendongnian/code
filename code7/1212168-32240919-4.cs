    List<char[]> lines = new List<char[]>();
    foreach (string line in File.ReadLines(sFileName))
    {
       lines.Append(line.ToCharArray());
    }
    char[] char_array = lines.ToArray();
