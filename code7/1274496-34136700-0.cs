    //instantiate the Dictionary
	Dictionary<string, List<string>> providerLevelChanges = new Dictionary<string, List<string>>();
		
	//Add the first item to the Dictionary - notice the empty List<string>
	providerLevelChanges.Add("someKey", new List<string>());
		
	//Add a value to the new List<string>
	providerLevelChanges["someKey"].Add("someNewValue");
