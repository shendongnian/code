    public static IEnumerable<string> ReadWords(this FileInfo fileInfo, Encoding enc)
    {
        using (var stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.None))
        {
            using (var reader = new StreamReader(stream))
            {
                do
                {
                    string[] line = reader.ReadLine().Split(' ');
                    foreach (string word in line)
                    {
                        if (word.StartsWith('b'))
                        yield return word;
                    }
                        
                } while (!reader.EndOfStream);
            }
        }
    }
