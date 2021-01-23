	var result = new StringBuilder();
	var resultArr = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
	Array.Sort(resultArr, StringComparer.InvariantCulture);
	foreach (string s in resultArr)
		result.AppendLine(s);
    output = result.ToString();	
