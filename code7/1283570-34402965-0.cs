    public async Task Work(string src, string spl)
    {
    
        // same as before
    
        log("Task 1 started. Please wait...");
    
        await Task.Factory.StartNew(() => StartProc(proc));
    
        log("Task 1 done.");
    }
