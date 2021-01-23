    public static string Format(string formatWithNames, IDictionary<string, object> data) {
        var reg = new Regex(@"[{]([^}]+)[}]", RegexOptions.IgnoreCase);
        var mc = reg.Matches(formatWithNames);
        var sb = new StringBuilder();
        var pos = 0;
        var args = new List<object>();
        var startIndex = 0;
        foreach (Match m in mc) {
            var g = m.Groups[1];
            var length = g.Index - startIndex;
            sb.Append(formatWithNames.Substring(startIndex, length));
            sb.Append(pos++);
            var tok = g.Value.Split(':');
            args.Add(data[tok[0]]);
            if (tok.Length == 2) {
                sb.Append(':');
                sb.Append(tok[1]);
            }
            startIndex = g.Index + g.Length;
        }
        if (startIndex < formatWithNames.Length) {
            sb.Append(formatWithNames.Substring(startIndex));
        }
        return string.Format(sb.ToString(), args.ToArray());
    }
