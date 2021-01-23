    public static IEnumerable<string> Group(this string s)
    {
        if (s == null) throw new ArgumentNullException("s");
    
        var index = 0;
        while (index < s.Length)
        {    
            var currentGroupChar = s[index];
            int groupSize = 1;
    
            while (index + 1 < s.Length && currentGroupChar == s[index + 1])
            {
                groupSize += 1;
                index += 1;
            }
    
            index += 1;
    
            yield return new string(currentGroupChar, groupSize);
        }
    }
