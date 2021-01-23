    public static string GetMooDStackTrace(string stackTrace)
    {
        var lines = stackTrace.Split('\n');
        int lastLineWithMood = -1;
    
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("MooD"))
                lastLineWithMood = i;
        }
    
        return string.Join("\n", lines, 0, lastLineWithMood + 1);
    }
