    var process = Process.Start(...);
    process.WaitForExit();
    int code = process.ExitCode;
    if (code != 0)
    {
       //failure
    }
    else
    {
       //success
    }
