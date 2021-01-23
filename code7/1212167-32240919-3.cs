    StringBuilder lines = new StringBuilder();
    foreach (string line in File.ReadLines(sFileName))
    {
       lines.Append(line);
    }
    char[] char_array = lines.ToString().ToCharArray();
