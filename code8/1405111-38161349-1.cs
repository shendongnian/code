    process.StartInfo.RedirectStandardError = true;
    // ...
    if (process.ExitCode != 0)
    {
        Console.WriteLine("encountered problems when copying file [{0}]", filePath);
        Console.WriteLine(process.StandardError.ReadToEnd());
    }
