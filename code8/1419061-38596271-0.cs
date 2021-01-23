    public static IEnumerable<string> GetBlocks(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            var sb = new StringBuilder();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (sb.Length != 0)
                        yield return sb.ToString();
                    sb.Clear();
                }
                else
                    sb.AppendLine(line);
            }
            if (sb.Length != 0)
                yield return sb.ToString();
        }
    }
