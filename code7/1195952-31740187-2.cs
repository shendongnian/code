    public static IEnumerable<string> Parse(string Input)
    {
        using (StringReader sr = new StringReader(Input))
        {
            int depth = 0;
            StringBuilder Line = new StringBuilder();
            while (sr.Peek() > -1)
            {
                char item = (char)sr.Read();
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
    }
