    proc.WaitForExit((int)TimeSpan.FromSeconds(10).TotalMilliseconds);
    
    var ret = new List<Dictionary<string, string>>();
    
    // first split on double newline to separate VMs
    string[] vms = proc.StandardOutput.ReadToEnd()
    	.Split(new[] { string.Format("{0}{0}", Environment.NewLine) }, StringSplitOptions.RemoveEmptyEntries);
    
    foreach (var vm in vms)
    {
    	// then split on newline, to get each line in separate string
    	var lines = vm.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    
    	// finally, split each line on ':' to fill in dictionary, then add it to list
    	ret.Add(lines.Select(line => line.Split(':')).ToDictionary(a => a[0].Trim(), a => a[1].Trim()));
    }
