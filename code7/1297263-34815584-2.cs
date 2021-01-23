    public static IDictionary<char, int> CountStuff(this string set)
    {
        var results = new Dictionary<char, int>();
        if (set == null)
            goto bottom;
        var enumerator = set.GetEnumerator();
    top:
        if (enumerator.MoveNext())
        {
            var v = (int)enumerator.Current;
            if (v < 97)
                v = v + 96;
            var c = (char)v;
            if (v < 97 || v > 122)
                goto top;
            if (results.ContainsKey(c))
                results[c]++;
            else
                results.Add(c, 1);
            goto top;
        }
    bottom:
        return results;
    }
