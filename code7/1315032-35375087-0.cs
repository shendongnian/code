    string SubstringFromFirstLetter(string s)
    {
        for (int i=0; i < s.Length; ++i)
        {
            if (char.IsLetter(s[i]))
            {
                return s.Substring(i);
            }
        }
        return "";
    }
