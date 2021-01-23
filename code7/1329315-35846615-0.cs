    var s = @"Start Date: xxxxx
    End Date: xxxx
    Warranty Type: xxxx
    Status: xxxx";
	var res = s.Split('\r', '\n')
	        .Where(p => !string.IsNullOrWhiteSpace(p))                  // Split into lines
	        .Select(m => m.Split(new[] {": "}, StringSplitOptions.None)) // Split each line with `:`+space
	        .ToDictionary(n => n[0], n => n[1]);              // Create a dictionary
    string strStartDate = string.Empty;
    string strEndDate = string.Empty;
    string Status = string.Empty;
    string Warranty = string.Empty;
    // Demo & variable assignment
	if (res.ContainsKey("Start Date")) {
        Console.WriteLine(res["Start Date"]);
        strStartDate = res["Start Date"];
    }
	if (res.ContainsKey("Warranty Type")) {
        Console.WriteLine(res["Warranty Type"]);
        Warranty = res["Warranty Type"];
    }
	if (res.ContainsKey("End Date")) {
        Console.WriteLine(res["End Date"]);
        strEndDate = res["End Date"];
    }
	if (res.ContainsKey("Status")) {
        Console.WriteLine(res["Status"]);
        string Status = res["Status"];
    }
