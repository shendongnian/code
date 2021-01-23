    string Soundex(string input)
    {
        // character groups: the 1st one are vowels to remove
        // the other groups are characters to replace by the group index
        List<string> groups = new List<string>() 
                             { "aeiouy", "bfpv", "cgjkqsxz", "dt", "l", "mn", "r" };
        // save the 1st character
        string first = input.Substring(0, 1);
        string s = input.ToLower();
        // remove unconditionally
        s = s.Replace("h", "").Replace("w", "");
        // replace characters in all replacement groups
        for (int g = 1; g < groups.Count; g++)
            for (int i = 0; i < groups[g].Length; i++)
                s = s.Replace(groups[g][i], ((char)(g + (byte)'0')));
        // replace repeating digits
        // NOTE: this step actually should be repeated until the length no longer changes!!!
        for (int i = 1; i < 10; i++) s = s.Replace(i + "" + i, i + "");
        // now remove characters from group 0:
        for (int i = 0; i < groups[0].Length; i++)  s = s.Replace(groups[0][i].ToString(), "");
        // remove the first if it is a digit
        if ( (s[0] >= '0') && (s[0] <= '9') ) s = s.Substring(1);
        // add saved first to max 3 digits and pad if needed
        return (first + s.Substring(0, Math.Min(3, s.Length))).PadRight(4, '0');
    }
