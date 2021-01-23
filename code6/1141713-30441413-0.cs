	public class SyntaxElementContainer<TKey> : Dictionary<string, string>
	{
		private const string Separator = "...";
		private static readonly string DeserializationPattern = GetFormattedRange(@"(\d+)", @"(\d+)");
		private static string GetFormattedRange(string start, string end)
		{
			return $"{start}{Separator}{end}";
		}
		public SyntaxElementContainer()
		{
		}
		public SyntaxElementContainer(ImmutableDictionary<string, string> propertyBag)
			: base(propertyBag)
		{
		}
		public void Add(TKey nodeKey, SyntaxNode node)
		{
			Add(nodeKey.ToString(), SerializeSpan(node?.Span));
        }
		public void Add(TKey tokenKey, SyntaxToken token)
		{
			Add(tokenKey.ToString(), SerializeSpan(token.Span));
		}
		public void Add(TKey triviaKey, SyntaxTrivia trivia)
		{
			Add(triviaKey.ToString(), SerializeSpan(trivia.Span));
		}
		public TextSpan GetTextSpanFromKey(string syntaxElementKey)
		{
			var spanAsText = this[syntaxElementKey];
			return DeSerializeSpan(spanAsText);
		}
		public int GetTextSpanStartFromKey(string syntaxElementKey)
		{
			var span = GetTextSpanFromKey(syntaxElementKey);
			return span.Start;
		}
		private string SerializeSpan(TextSpan? span)
		{
			var actualSpan = span == null || span.Value.IsEmpty ? default(TextSpan) : span.Value; 
			return GetFormattedRange(actualSpan.Start.ToString(), actualSpan.End.ToString());
		}
		private TextSpan DeSerializeSpan(string spanAsText)
		{
			var match = Regex.Match(spanAsText, DeserializationPattern);
			if (match.Success)
			{
				var spanStartAsText = match.Groups[1].Captures[0].Value;
				var spanEndAsText = match.Groups[2].Captures[0].Value;
				
				return TextSpan.FromBounds(int.Parse(spanStartAsText), int.Parse(spanEndAsText));
			}
			return new TextSpan();
		}	
	}
