    Process[] processes = Process.GetProcessesByName("winword");
    foreach (var process in processes)
    {
        try
        {
            process.Kill();
        }
        catch (Exception)
        {
        // handle the exception...                    
        }
                        
    }
    // That solved the problem.
    // Thanks for your help :-).
