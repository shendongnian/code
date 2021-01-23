	public enum WordTypes
	{
		Noun,
		Verb,
		Adjective,
		Adverb,
		Unknown
	}
	public class Definition
	{
		public Definition()
		{
			Synonyms = new List<string>();
			Anotnyms = new List<string>();
		}
		public WordTypes WordType { get; set; }
		public string DefinitionText { get; set; }
		public List<string> Synonyms { get; set; }
		public List<string> Anotnyms { get; set; }
	}
		
	static class DefinitionParser
	{
		public static List<Definition> Parse(string wordDefinition)
		{
			var wordDefinitionLines = wordDefinition.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
				.Skip(1)
				.Select(x => x.Trim())
				.ToList();
			var flatenedList = MakeLists(wordDefinitionLines).SelectMany(x => x).ToList();
			var result = new List<Definition>();
			foreach (var wd in flatenedList)
			{
				var foundMatch = Regex.Match(wd, @"^(?<matchType>adv|adj|v|n){0,1}\s*(\d*): (?<definition>[\w\s;""',\.\(\)\!\-]+)(?<extraInfoSyns>\[syn: ((?<wordSyn>\{[\w\s\-]+\})|(?:[,\ ]))*\]){0,1}\s*(?<extraInfoAnts>\[ant: ((?<wordAnt>\{[\w\s-]+\})|(?:[,\ ]))*\]){0,1}");
				var def = new Definition();
				if (foundMatch.Groups["matchType"].Success)
				{
					var matchType = foundMatch.Groups["matchType"];
					def.WordType = DefinitionTypeToEnum(matchType.Value);
				}
				if (foundMatch.Groups["definition"].Success)
				{
					var definition = foundMatch.Groups["definition"];
					def.DefinitionText = definition.Value;
				}
				if (foundMatch.Groups["extraInfoSyns"].Success && foundMatch.Groups["wordSyn"].Success)
				{
					foreach (Capture capture in foundMatch.Groups["wordSyn"].Captures)
					{
						def.Synonyms.Add(capture.Value.Trim('{','}'));
					}
				}
				if (foundMatch.Groups["extraInfoAnts"].Success && foundMatch.Groups["wordAnt"].Success)
				{
					foreach (Capture capture in foundMatch.Groups["wordAnt"].Captures)
					{
						def.Anotnyms.Add(capture.Value.Trim('{', '}'));
					}
				}
				result.Add(def);
			}
			return result;
		}
		private static List<List<string>> MakeLists(IEnumerable<string> text)
		{
			List<List<string>> types = new List<List<string>>();
			int i = -1;
			int j = 0;
			foreach (var line in text)
			{
				// New type (Noun, Verb, Adj.)
				if (Regex.IsMatch(line, "^(adj|v|n|adv){1}\\s\\d*"))
				{
					types.Add(new List<string> { line });
					i++;
					j = 0;
				}
				// New definition in the previous type
				else if (Regex.IsMatch(line, "^\\d+"))
				{
					j++;
					types[i].Add(line);
				}
				// New line of the same definition
				else
				{
					types[i][j] = types[i][j] + " " + line;
				}
			}
			return types;
		}
		private static WordTypes DefinitionTypeToEnum(string input)
		{
			switch (input)
			{
				case "adj":
					return WordTypes.Adjective;
				case "adv":
					return WordTypes.Adverb;
				case "n":
					return WordTypes.Noun;
				case "v":
					return WordTypes.Verb;
				default:
					return WordTypes.Unknown;
			}
		}
	}
