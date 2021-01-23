    // This creates the thread that calls ReadCoils() or, in my case,
    // waits for 10 seconds.
    Thread newThread = new System.Threading.Thread(() =>
    {
        // I replaced the following with "Thread.Sleep(10 * 1000);" to test
        master.ReadCoils(slaveId, 13, numRegisters);        
    });
    // Run the thread
    newThread.Start();
    System.Threading.Thread.Sleep(5);
    if (newThread.IsAlive)
    {
        // Stop the thread if it is still running.        
        newThread.Abort();
    }
