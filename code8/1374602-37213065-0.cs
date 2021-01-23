    public static void ReplaceLine(string filename, string text, int linenumber)
    {
        string[] allLines = File.ReadAllLines(filename);
        if (allLines.Length < linenumber)
            return; // or ArgumentException?
        allLines[linenumber - 1] = text;
        File.WriteAllLines(filename, allLines);
    }
