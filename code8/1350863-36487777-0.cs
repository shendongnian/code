    process.OutputDataReceived += (sender, line) =>
    {
        if (line.Data != null)
            Console.WriteLine(line.Data);
    };
    
    process.BeginOutputReadLine();
    
    process.WaitForExit();
