    private static IEnumerable<string> ReadWords(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            string word = "";
            while (!reader.EndOfStream)
            {
                char c = (char)reader.Read();
                if (char.IsWhiteSpace(c))
                {
                    if (word != "")
                    {
                        yield return word;
                        word = "";
                    }
                }
                else
                {
                    word += c;
                }
            }
            yield return word;
        }
    }
