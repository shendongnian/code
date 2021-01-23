    public static string[] GetNamesOnLine(int lineIndex, string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        if (lineIndex >= lines.Length)
            throw new ArgumentException(String.Format("Line {0} does not exist in file. File contains only {1} rows", lineIndex, lines.Length));
                
        return lines[lineIndex].Split(',');
    }
