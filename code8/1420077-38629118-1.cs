    public static string RemoveDuplicates(this string s)
    {
        if (String.IsNullOrEmpty(s)) return String.Empty();
        s.AsEnumerable().Take(1)
            .Concat(s.AsEnumerable().Skip(1)
                .where( (c, i) => c != s[i]));
    }
