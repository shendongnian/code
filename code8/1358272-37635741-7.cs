	class ParseyMcParseface
	{
		/// <summary>
		/// Word definition lines
		/// </summary>
		private string[] _text;
		/// <summary>
		/// Constructor (Takes the innerText of the WordDefinition tag as input
		/// </summary>
		/// <param name="text">innerText of the WordDefinition</param>
		public ParseyMcParseface(string text)
		{
			_text = text.Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
				.Skip(1) // Skip the first line where the word is mentioned
				.ToArray();
		}
		/// <summary>
		/// Convert from single letter type to full human readable type
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		private string CharToType(char c)
		{
			switch (c)
			{
				case 'a':
					return "Adjective";
				case 'n':
					return "Noun";
				case 'v':
					return "Verb";
				default:
					return "Unknown";
			}
		}
		/// <summary>
		/// Reorganize the data for easier parsing
		/// </summary>
		/// <param name="text">Lines of text</param>
		/// <returns></returns>
		private static List<List<string>> MakeLists(IEnumerable<string> text)
		{
			List<List<string>> types = new List<List<string>>();
			int i = -1;
			int j = 0;
			foreach (var line in text)
			{
				// New type (Noun, Verb, Adj.)
				if (Regex.IsMatch(line.Trim(), "^[avn]{1}\\ \\d+"))
				{
					types.Add(new List<string> { line.Trim() });
					i++;
					j = 0;
				}
				// New definition in the previous type
				else if (Regex.IsMatch(line.Trim(), "^\\d+"))
				{
					j++;
					types[i].Add(line.Trim());
				}
				// New line of the same definition
				else
				{
					types[i][j] = types[i][j] + " " + line.Trim();
				}
			}
			return types;
		}
		public List<Definition> Parse()
		{
			var definitionsLines = MakeLists(_text);
			List<Definition> definitions = new List<Definition>();
			foreach (var type in definitionsLines)
			{
				var defs = new List<Def>();
				foreach (var def in type)
				{
					var match = Regex.Match(def.Trim(), "(?:\\:\\ )(\\w|\\ |;|\"|,|\\.)*[\\[]{0,1}");
					MatchCollection syns = Regex.Matches(def.Trim(), "\\{(\\w|\\ )+\\}");
					List<string> synonymes = new List<string>();
					foreach (Match syn in syns)
					{
						synonymes.Add(syn.Value.Trim('{', '}'));
					}
					defs.Add(new Def()
					{
						text = match.Value.Trim(':', '[', ' '),
						synonym = synonymes
					});
				}
				definitions.Add(new Definition
				{
					type = CharToType(type[0][0]),
					Def = defs
				});
			}
			return definitions;
		}
	}
