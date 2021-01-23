    Process process = new Process();
    process.StartInfo.FileName = DestinationFile;
    process.StartInfo.Verb = "print";
    process.Start();
    // In case of Adobe Reader the following statement is needed:
    process.WaitForInputIdle();
    
    process.WaitForExit(2000);
    process.WaitForInputIdle();
    process.Kill();
