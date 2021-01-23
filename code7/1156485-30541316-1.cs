		string stringValue = "fffeefef";
		
		int characterChanges = 0;
		for(int i = 1; i < stringValue.Length; i++)	
		{
			if(stringValue[i] != stringValue[i - 1])
			{
				characterChanges++;
			}
		}
		
		Console.WriteLine("Character changed {0} times.", characterChanges);
