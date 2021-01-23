	public static string Reverse(string text, Func<char, bool> separatorPredicate)
	{
		// Get all chars from source text
		var aTextChars = text.ToCharArray();
		// Find the start and end position of every chunk
		var aChunks = new List<Tuple<int, int, bool>>();
		{
			var bLast = false;
			var ixStart = 0;
			// Loops all characters
			for (int ixChar = 0; ixChar < aTextChars.Length; ixChar++)
			{
				var ch = aTextChars[ixChar];
				// Current char is a separator?
				var bNow = separatorPredicate(ch);
				// Current char kind (separator/word) is different from previous
				if ((ixChar > 0) && (bNow != bLast))
				{
					aChunks.Add(Tuple.Create(ixStart, ixChar - 1, bLast));
					ixStart = ixChar;
					bLast = bNow;
				}
			}
			// Add remaining chars
			aChunks.Add(Tuple.Create(ixStart, aTextChars.Length - 1, bLast));
		}
		var result = new StringBuilder();
		// Loops all chunks in reverse order
		for (int ixChunk = aChunks.Count - 1; ixChunk >= 0; ixChunk--)
		{
			var chunk = aChunks[ixChunk];
			result.Append(text.Substring(chunk.Item1, chunk.Item2 - chunk.Item1 + 1));
		}
		return result.ToString();
	}
	public static string Reverse(string text, char[] separators)
	{
		return Reverse(text, ch => Array.IndexOf(separators, ch) >= 0);
	}
	public static string ReverseByPunctuation(string text)
	{
		return Reverse(text, new[] { ' ', '\t', '.', ',', ';', ':' });
	}
	public static string ReverseWords(string text)
	{
		return Reverse(text, ch => !char.IsLetterOrDigit(ch));
	}
