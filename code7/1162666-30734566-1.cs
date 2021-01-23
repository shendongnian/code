    public string[] wordList;
    public class WordItem
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
    
    public IEnumerable<WordItem> FindWordCount()
    {
      return from word in wordList
    		 group word by word.ToLowerInvariant() into g
    		 select new WordItem { Word = g.Key, Count = g.Count()};
    }
