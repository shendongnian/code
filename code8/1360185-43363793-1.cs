    public static string Escape(string s)
    {
        if (s == null) return s;
    
        var sb = new StringBuilder();
        foreach (char c in s)
        {
            if (c >= 0x20 && c < 0x80)
            {
                if (c == '\\' || c == '{' || c == '}')
                {
                    sb.Append('\\');
                }
                sb.Append(c);
            }
            else if (c < 0x20 || (c >= 0x80 && c <= 0xFF))
            {
                sb.Append(@"\'");
                sb.Append(Convert.ToByte(c).ToString("X"));
            }
            else
            {
                sb.Append("\\u");
                sb.Append((short)c);
                sb.Append("??");//two bytes ignored
            }
        }
        return sb.ToString();
    }
