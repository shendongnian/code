    public class WordCount
    {
        public int Count;
    }
    ...
    var wordCount = new Dictionary<string, WordCount>();
    ...
    string word = line.Substring(lastPos, index - lastPos);
    WordCount currentCount;
    if (!wordCount.TryGetValue(word, out currentCount))
        wordCount[word] = currentCount = new WordCount();
    currentCount.Count++;
