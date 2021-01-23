	Dictionary<string, Action<string>> imageActions = new Dictionary<string, Action<string>>();
	if (match.Success && imageActions.ContainsKey(match.Value))   // If image abides by the format and a delegate exists for handling that image name
	    imageActions[match.Value](match.Value);
    // usage
    imageActions.Add("Tree", i => { /* Logic */ });
