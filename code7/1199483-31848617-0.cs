    // In the server
    var mutex = new System.Threading.Mutex(false, "MyPipeMutex");
    OpenPipeAndRunServer();
    mutex.Close();
    // In the client process    
    var mutex = new System.Threading.Mutex(false, "MyPipeMutex");
    if (!mutex.WaitOne(0, false))
    {
        OpenPipe();
    }
    mutex.Close();
