    string[] names = 
    {
		"Jordan Ghassari",
		"James Cunningham",
		"Ghabriel Bercholee",
		"O^Brian",
		"Depto #345",
	    "This is Ex$ample"
    };
	
	string searchFor = "Ex$a"; // Input
	searchFor = @"\b" + Regex.Escape(searchFor); // searchFor is input value to look for
    Regex regEx = new Regex(searchFor, RegexOptions.IgnoreCase);
	
	List<string> matchedNames = new List<string>();
	foreach(string name in names){
        if (regEx.IsMatch(name))
        {
			matchedNames.Add(name);
		}
	}
