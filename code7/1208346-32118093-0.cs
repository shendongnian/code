    var data = new Dictionary<string, int> {
    	{ "C1", 1},
    	{ "C2", 2},
    	{ "C3", 3}
    };
    var expandoObject = new ExpandoObject() as IDictionary<string, Object>;
    foreach (var kvp in data) {
    	expandoObject.Add(kvp.Key, kvp.Value);
    }
    dynamic pivotedData = expandoObject;
    
    Console.WriteLine(pivotedData.C1);
    Console.WriteLine(pivotedData.C2);
    Console.WriteLine(pivotedData.C3);
    Console.ReadLine();
