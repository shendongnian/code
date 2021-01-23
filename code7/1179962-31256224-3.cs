    private static IEnumerable<string> ReadWords(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            var builder = new StringBuilder();
            while (!reader.EndOfStream)
            {
                char c = (char)reader.Read();
                // Mimic regex /w/.
                if (char.IsLetterOrDigit(c) || c == '_')
                {
                    builder.Append(c);
                }
                else
                {
                    if (builder.Length > 0)
                    {
                        yield return builder.ToString();
                        builder.Clear();
                    }
                }
            }
            yield return builder.ToString();
        }
    }
