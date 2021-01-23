    public static  IEnumerable<string> Parse(string Input)
    {
        using (StringReader sr = new StringReader(Input))
        {
            int depth = 0;
            string Line = string.Empty;
            while (sr.Peek() > -1)
            {                    
                char item = (char)sr.Read();
                if (depth == 0 && item == ',')
                {
                    yield return Line;
                    Line = string.Empty;
                }
                else
                {
                    Line += item;
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
        }
    }
