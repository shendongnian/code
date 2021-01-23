    var username = "Aron2";
    var password = "asdd";
    List<string> matchedValues; // Contains field values of matched line.
    var lines = File.ReadLines("input.txt");
    
    foreach (string l in lines)
    {
    	var values = l.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
     
    	if (values.Contains(username) && values.Contains(password))
    	{
    		matchedValues = values;
    		break; // Matching line found. No need to loop further.
    	}
    }
