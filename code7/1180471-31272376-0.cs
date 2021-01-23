    string ParseUnicodeHex(string hex)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i+=4)
        {
            string temp = s.Substring(i, 4);
            char character = (char)Convert.ToInt16(temp, 16);
            sb.Append(character);
        }
        return sb.ToString();
    }
