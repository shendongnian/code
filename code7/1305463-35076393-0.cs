    var list1 = new List<List<string>> {
    	new List<string> { "dd", "ff" },
    	new List<string> { "dd", "ff" },
    	new List<string> { "dd", "ff" }};
    	
    var list2 = new List<List<string>> {
    	new List<string> { "gg", "hh" },
    	new List<string> { "gg", "uu" },
    	new List<string> { "hh", "uu" }};
    
    for(var j = 0; j < list1.Count(); j++)
    {
    	list1.ElementAt(j).AddRange(list2.ElementAt(j));
    }
