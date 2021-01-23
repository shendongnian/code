    public static IEnumerable<string> SplitScriptOnGo(string scriptPath)
    {
        var buffer = new StringBuilder();
        foreach (var line in File.ReadLines(scriptPath))
        {
            if (line == "GO")
            {
                yield return buffer.ToString();
                buffer.Clear();
            }
            else
            {
                buffer.AppendLine(line);
            }
        }
    }
