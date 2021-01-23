    public static IEnumerable<string> Group(this string s)
    {
        if (s == null) throw new ArgumentNullException("s");
        var index = 0;
        while (index < s.Length)
        {
            var groupBuilder = new StringBuilder();
            var currentGroupChar = s[index];
            groupBuilder.Append(currentGroupChar);
            while (index + 1 < s.Length && currentGroupChar == s[index + 1])
            {
                groupBuilder.Append(currentGroupChar );
                index += 1;
            }
    
            index += 1;
    
            yield return groupBuilder.ToString();
        }
    }
