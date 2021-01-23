    proc.WaitForExit((int)TimeSpan.FromSeconds(10).TotalMilliseconds);
    
    // an array of StandardOutput lines - empty lines removed
    string[] stdOut = proc.StandardOutput.ReadToEnd()
        .Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    
    // split each line on ':' and trim strings before putting them in dictionary
    Dictionary<string, string> dict = stdOut.Select(line => line.Split(':'))
        .ToDictionary(a => a[0].Trim(), a => a[1].Trim());
