    IDictionary<string, int> database = new Dictionary<string, int>
    {
    	{"Week1 Monday", 10},
    	{"Week1 Wednesday", 20}
    };
    
    var userinput = "Week1 Monday";
    int numberOfBears;
    database.TryGetValue(userinput, out numberOfBears);
    //numberOfBears = 10
