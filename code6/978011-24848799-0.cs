    public IEnumerable<List<string>> ReadSeparatedLines(string file)
    {
        List<string> lines = new List<string>();
        foreach (var line in File.ReadLines(file))
        {
            if (line == "")
            {
                // Only take action if we've actually got something to return. This
                // handles files starting with blank lines, and also files with
                // multiple consecutive blank lines.
                if (lines.Count > 0)
                {
                    yield return lines;
                    lines = new List<string>();
                }
            }
            else
            {
                lines.Add(line);
            }
        }
        // Check whether we had any trailing lines to return
        if (lines.Count > 0)
        {
            yield return lines;
        }
    }
