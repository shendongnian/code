    string nstatus = status;
    // Loops here forever
    while (nstatus != "Done")
    {
        //Thread.Sleep(25); // Tried this as well, same result
        Thread.SpinWait(1);
        nstatus = Volatile.Read(ref status);
    }
