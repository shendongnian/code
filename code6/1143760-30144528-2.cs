    public static IEnumerable<string> UnicodeXmlEscape(IEnumerable<string> input)
    {
        var sb = new StringBuilder();
        foreach (var line in input)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsSurrogatePair(line, i))
                    sb.AppendFormat(@"&#x{0:x8}", char.ConvertToUtf32(line, i++)); // i++ to skip next one.
                else
                {
                    int ci = char.ConvertToUtf32(line, i);
                    if (ci > 127)
                        sb.AppendFormat(@"&#x{0:x4}", ci);
                    else
                        sb.Append(line[i]);
                }
            }
            yield return sb.ToString();
            sb.Clear();
        }
    }
