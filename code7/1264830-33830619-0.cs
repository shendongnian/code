    public static IEnumerable<IList<string>> ParseDelimitedLines(
        this IEnumerable<string> lines,
        char delimiter,
        char? singleEscape,
        char? beginEndEscape)
    {
        var row = new List<string>();
        var currentItem = new StringBuilder();
        bool previousSingleEscape = false;
        bool insideEscape = false;
        bool needsAppendLine = false;
        foreach (var line in lines)
        {
            previousSingleEscape = false;
            if (needsAppendLine)
            {
                currentItem.AppendLine();
                needsAppendLine = false;
            }
            foreach (char c in line)
            {
                if (c == beginEndEscape && !previousSingleEscape)
                {
                    insideEscape = !insideEscape;
                }
                if (c == delimiter && !previousSingleEscape && !insideEscape)
                {
                    row.Add(currentItem.ToString());
                    currentItem.Clear();
                    continue;
                }
                previousSingleEscape = c == singleEscape && !previousSingleEscape;
                if(!previousSingleEscape)
                    currentItem.Append(c);
            }
            if (!insideEscape && !previousSingleEscape)
            {
                row.Add(currentItem.ToString());
                yield return row;
                row = new List<string>();
                currentItem.Clear();
            }
            else
            {
                needsAppendLine = true;
            }
        }
        if (insideEscape || previousSingleEscape)
        {
            row.Add(currentItem.ToString());
            yield return row;
        }
    }
