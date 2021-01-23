	Dictionary<string, List<string>> oDict = new Dictionary<string, List<string>>();
	
	oDict.Add("Key1", new List<string>{"AA", "BB", "JX", "TR", "FT"});
    oDict.Add("Key2", new List<string>{"AX", "BC", "SF", "XO", "ST"});
    oDict.Add("Key3", new List<string>{"22", "22", "22", "21", "21"});
    oDict.Add("Key4", new List<string>{"AW", "BM", "ND", "NC", "PO"});
    oDict.Add("Key5", new List<string>{"AZ", "BN", "SD", "DS", "ZX"}); 
	//key to find
	string searchedKey = "Key3";
    //value to find
	string searchedValue = "22";
	//get index of Key
	var keyIndex = oDict.Keys.ToList().IndexOf(searchedKey);  //if not found, returns -1
	//returns 2
	//get the list of indexes where the value has been found
	var valIndexes = Enumerable.Range(0, oDict[searchedKey].Count)
                 .Where(i => oDict[searchedKey][i] == searchedValue)
				 .ToList();
	//returns: {0, 1, 2}
		
    //get distination resultset
	var resultSubset = oDict
                        .Take(keyIndex+1) //take the no. of Keys
						.ToDictionary(a=>a.Key,
								a=>a.Value.Where((x,z) => valIndexes
														.Any(i=> i==z)) 
														.Select(x=>x).ToList());
