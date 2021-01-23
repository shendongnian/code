    public List<string> Parse(string str)
    {
        var parts = str.Split(new[] {"|"}, StringSplitOptions.None);
        List<string> result = new List<string>();
        for (int i = 0; i < parts.Length; i++)
        {
            string part = parts[i];
            if (IsPartStart(part))
            {
                List<string> sub_parts = new List<string>();
                do
                {
                    sub_parts.Add(part);
                    i++;
                    part = parts[i];
                } while (!IsPartEnd(part));
                sub_parts.Add(part);
                part = string.Join("|", sub_parts);
            }
            result.Add(part);
        }
        return result;
    }
    private bool IsPartStart(string part)
    {
        return (part.StartsWith("\"") && !part.EndsWith("\"")) ;
    }
    private bool IsPartEnd(string part)
    {
        return (!part.StartsWith("\"") && part.EndsWith("\""));
    }
