			string[] lines = File.ReadAllLines("SourceFile.txt");
			var lineHeight = 4;
			var text = new StringBuilder();
			for (var i = 0; i < lines.Length; i += lineHeight)
			{
				var j = 0;
				while (j < lines[i].Length)
				{
					var match = Alphabet.All.FirstOrDefault(character => character.Match(lines, i, j));
					if (match != null)
					{
						text.Append(match.Character);
						j += match.Width;
					}
					else
					{
						j++;
					}
				}
			}
			Console.WriteLine("Recognized numbers: {0}", text.ToString());
