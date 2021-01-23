	static bool CheckFormat(string formatString, string value)
	{
		string[] tests = formatString.Split('+');
		
		foreach(string test in tests)
		{
			string[] testElement = test.Split(':');
			int startPos = int.Parse(testElement[0]);
			string patterns = testElement[1];
			
			string[] patternElements = patterns.Split(',');
			
			foreach(string patternElement in patternElements)
			{
			
				//value string not long enough, so fail.
				if(startPos + patternElement.Length > value.Length)
					return false;
			
				for (int i = 0; i < patternElement.Length; i++)
            	{
					switch(patternElement[i])
					{
						case '#':
							if (!Char.IsNumber(value[i]))
								return false;
							break;
						case '&':
							if (!Char.IsLetter(value[i]))
								return false;
							break;
						
						default:
						
							if(patternElement[i] != value[i])
								return false;
							break;
						
					}
            	}
			}
		}
		
		return true;
	}
	
