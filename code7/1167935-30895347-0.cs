    public static string removeAtIndexes(string source)
    {
        var indexes = new Tuple<int, int>[]
        {
            new Tuple<int, int>(15, 19),
            new Tuple<int, int>(16, 18),
            new Tuple<int, int>(19, 21)
        };
    
        var sb = new StringBuilder();
    
        var last = 0;
        bool copying = true;
        for (var i = 0; i < source.Length; i++)
        {
            var end = false;
    
            foreach (var index in indexes)
            {
                if (copying)
                {
                    if (index.Item1 <= i)
                    {
                        copying = false;
                        break;
                    }
                }
                else
                {
                    if (index.Item2 < i)
                    {
                        end = true;
                    }
                }
            }
    
            if (false == copying && end)
            {
                copying = true;
            }
    
            if(copying)
            {
                sb.Append(source[i]);
            }
        }
    
        return sb.ToString();
    }
