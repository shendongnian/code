    var process = Process.Start(shortcutPath, arguments);
    if (process != null && process.HasExited != true)
    {
        process.WaitForExit();
    }
    else
    {
        // Process is null or have exited
    }
