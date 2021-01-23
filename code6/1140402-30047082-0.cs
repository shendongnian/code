    string Input = "919982115672";
    Console.Write(Search(Input));
	public string Search(string Input)
	{
	
		Dictionary<string, string> PreDefinedSearchAndTexts = new Dictionary<string, string>();
		
		PreDefinedSearchAndTexts.Add("8211", "Hello");
		PreDefinedSearchAndTexts.Add("82", "My name is inigo montya");
		PreDefinedSearchAndTexts.Add("9821", "You killed my father");
		PreDefinedSearchAndTexts.Add("5672", "Prepare to die");
		
		StringBuilder sb = new StringBuilder(); 
		
		foreach(string Key in PreDefinedSearchAndTexts.Keys) 
		{
			if(Input.Contains(Key))
			{
				sb.Append(Key).Append(" : ").AppendLine(PreDefinedSearchAndTexts[Key]);
			}
		}
		return sb.ToString();
	}
