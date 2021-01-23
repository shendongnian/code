    public static Func<int, bool> Parse(string criteria)
    {
        var alternatives = criteria
            .Split('|')
            .Select<string, Func<int, bool>>(
                token =>
                {
                    if (token.Contains(".."))
                    {
                        var between = token.Split(new[] {".."}, StringSplitOptions.RemoveEmptyEntries);
                        int lo = int.Parse(between[0]);
                        int hi = int.Parse(between[1]);
                        return x => lo <= x && x <= hi;
                    }
                    else
                    {
                        int exact = int.Parse(token);
                        return x => x == exact;
                    }
                })
            .ToArray();
        return x => alternatives.Any(alt => alt(x));
    }
