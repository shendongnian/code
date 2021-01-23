    // ...
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    // ...
    process.Start();
    
    StreamReader results = process.StandardOutput;
    StreamWriter processInput = process.StandardInput;
    foreach( var arg in args )
    {
        processInput.WriteLine(arg);
        var oneResult = results.ReadLine();
        // do something with this oneResult
    }
