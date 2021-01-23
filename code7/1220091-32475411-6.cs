    var numberOfLines = 7; // Choose how many lines you want.
	var xAxisHeadings = new object[] { "NOT USED", "Original Documents", "Filing of Entries", "Assessment of Duties", "Payment of Duties", "Releasing", "Gate Pass", "Delivery" };
	var lines = new List<object[]>();
	lines.Add(xAxisHeadings);
    // Each line needs to be an array with the first value being the name of the line 
    // (e.g. Standard, Latest, Earliest, Average in your case) and the rest
    // being the actual values in order.
    // In the following example, line n has values n, 2n, 3n, 4n, 5n, 6n, 7n
    // e.g. line seven has the values 7, 14, 21, 28, 35, 42, 49 
	for (int i=0; i<numberOfLines; i++)
	{
		lines.Add(new object[] { "L" + i, 1 * (i+1), 2 * (i+1), 3 * (i+1), 4 * (i+1), 5 * (i+1), 6 * (i+1), 7 * (i+1) });
	}
	
	var answer = new List<object>{};
	for (int i=0; i<lines.Count; i++)
	{
		var x = lines.Select(a => a[i]).ToArray();
		answer.Add(x);
	}
	
	var json = Newtonsoft.Json.JsonConvert.SerializeObject(answer);
