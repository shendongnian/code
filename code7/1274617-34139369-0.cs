    Dictionary<string, Dictionary<string, List<string>>> myDictionary = new Dictionary<string, Dictionary<string, List<string>>>();
    if (!myDictionary.ContainsKey("outerKey"))
    {
	   var innerDictiionary= new Dictionary<string, List<string>>();
       var data= new List<sting>(){
		"hello"
	};
	innerDictiionary.Add("innerKey", data);
    myDictionary.Add("outerKey",  innerDictiionary);
    }
