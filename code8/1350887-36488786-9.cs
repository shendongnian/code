		public string ToSubscriptFormula(string input)
		{
			var characters = input.ToCharArray();
			for (var i = 0; i < characters.Length; i++)
			{
				switch (characters[i])
				{
					case '2':
						characters[i] = '₂';
						break;
					case '3':
						characters[i] = '₃';
						break;
                   // case statements omitted
				}
			}
			return new string(characters);
		}
