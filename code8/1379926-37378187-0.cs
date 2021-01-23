	void Main()
	{
		var sentence = "Stackoverflow helps developers, as it helps with development tasks, and is a useful developers resource. A non-trivial solution involves edge cases.";
	
		var wordTracker = new WordTracker(sentence);
		
		wordTracker.WriteAll();
		Console.WriteLine(wordTracker.IndexOf("developers")); //Writes 3
		Console.WriteLine(wordTracker.IndexOf("notfound")); //Writes -1
		Console.WriteLine(wordTracker.IndexOf("non-trivial")); //Writes 17
		Console.WriteLine(wordTracker.WordAt(13)); //Writes "useful"
	}
	
	public class WordTracker {
		private static readonly Regex _wordRegex = new Regex(@"[\S]*\w");
		private readonly Dictionary<string, int> _wordPositions = new Dictionary<string, int>();
		private List<WordPosition> _words;
		
		public WordTracker(string input) {
			BuildWordPositions(input);
		}
		
		public int IndexOf(string word) {
			int index;
			return _wordPositions.TryGetValue(word, out index)
				? index + 1 //From the example, we're 1-indexed
				: -1;
		}
		
		public string WordAt(int index)
		{
			index = index - 1; //From the example, we're 1-indexed
			if (index < 0) throw new ArgumentException("Index must be positive");
			if (index >= _words.Count) throw new ArgumentOutOfRangeException("index");
			
			return _words[index].Word;
		}
		
		public void WriteAll() {
			foreach (var kvp in _wordPositions) {
				Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
			}
		}
		
		private void BuildWordPositions(string input)
		{
			_words = input.Split(' ')
				.Select((m, i) => new WordPosition(i, m)).ToList();
			var wordGroups = _words.GroupBy(m => m.Word);
		
			foreach (var wordGroup in wordGroups) {
				_wordPositions.Add(wordGroup.Key, wordGroup.First().Index);
			}
		}
		
		private class WordPosition
		{
			public WordPosition(int index, string word) {
				Index = index;
				Word = _wordRegex.Match(word).Value.ToLower();
			}
			
			public int Index { get; private set; }
			public string Word { get; private set; }
		}
	}
