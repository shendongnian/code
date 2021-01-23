    public static string Escape(string s)
    {
        if (s == null) return s;
    
        int len = s.Length;
        var sb = new StringBuilder(len);
        for (int i = 0; i < len; i++)
        {
            char c = s[i];
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
