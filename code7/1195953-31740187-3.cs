    public static IEnumerable<string> Parse(string Input)
    {
        int depth = 0;
        StringBuilder Line = new StringBuilder();
        foreach (char item in Input)
        {
            if (depth == 0 && item == ',')
            {
                yield return Line.ToString();
                Line = new StringBuilder();
            }
            else
            {
                Line.Append(item);
                if (item == '(')
                {
                    depth++;
                }
                if (item == ')')
                {
                    depth--;
                }
            }
        }
        if (Line.Length > 0)
            yield return Line.ToString();
    }
