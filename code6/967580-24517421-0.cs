    public static Regex ConvertToRegex(string pattern)
    {
        var sb = new StringBuilder();
        sb.Append("^");
        foreach (var c in pattern)
        {
            switch (c)
            {
                case '#':
                    sb.Append(@"\d");
                    break;
                default:
                    sb.Append(Regex.Escape(c.ToString()));
                    break;
            }
        }
        sb.Append("$");
        return new Regex(sb.ToString());
    }
