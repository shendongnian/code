    // get the current process
    Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
    
    // get the physical mem usage
    long totalBytesOfMemoryUsed = currentProcess.WorkingSet64;
