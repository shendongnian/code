    // ...
    string regexStr = Calculate(skus);
    // ...
    public static string Calculate(IEnumerable<string> rest) {
        if (rest.First().Length > 0) {
            string[] groups = rest.GroupBy(r => r[0])
                .Select(g => g.Key + Calculate(g.Select(e => e.Substring(1))))
                .ToArray();
            return groups.Length > 1 ? "(" + string.Join("|", groups) + ")" : groups[0];
        } else {
            return string.Empty;
        }
    }
