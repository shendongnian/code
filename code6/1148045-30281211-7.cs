    public class WordCount
    {
        public int Count;
    }
    public static IDictionary<string, WordCount> Parse(string path)
    {
        var wordCount = new Dictionary<string, WordCount>();
        using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 65536))
        using (var streamReader = new StreamReader(fileStream, Encoding.Default, false, 65536))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                int lastPos = 0;
                for (int index = 0; index <= line.Length; index++)
                {
                    if (index == line.Length || line[index] == ' ')
                    {
                        if (lastPos < index)
                        {
                            string word = line.Substring(lastPos, index - lastPos);
                            WordCount currentCount;
                            if (!wordCount.TryGetValue(word, out currentCount))
                                wordCount[word] = currentCount = new WordCount();
                            currentCount.Count++;
                        }
                        lastPos = index + 1;
                    }
                }
            }
        }
        return wordCount;
    }
