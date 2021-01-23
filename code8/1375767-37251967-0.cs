    //use timer
    //runTimer(); //Not needed now
    Task.Factory.StartNew(()=>{
    using (Process proc = Process.Start(start))
    {
    proc.WaitForExit();
    }
    work(); //If you need to wait  the process to finish
    });
    work(); //If you don't need to wait  the process to finish`
