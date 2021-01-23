        bool[] seenChars = new bool[128];
		var sb = new StringBuilder();
		
		foreach(char c in stringOne)
		{
			if(!seenChars[c]){
				seenChars[c] = true;
				sb.Append(c);
			}
		}
		
		return sb.ToString();
