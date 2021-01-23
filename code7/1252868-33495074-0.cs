    public void StartNewThread()
    {
        const int stacksize = 1024*1024; // 1MB
        var thread = new Thread(NativeDllProcess, stacksize);
        thread.Start();
        thread.Join(); // Wait till thread is ready
        // .. rest of code here
    }
    private void NativeDllProcess(object info)
    {
        // ..... Code thats calls C dll functions
    }
