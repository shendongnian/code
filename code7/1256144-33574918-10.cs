    // Real name of the named pipe, thanks Divi!
    string pipeAccess = String.Format(@"\\.\pipe\{0}", Program.pipeGuid);
    
    // Get our handle to the named pipe
    IntPtr pipe = CreateFile(pipeAccess, FileAccess.ReadWrite,
        0, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
    
    uint pid = 0;
    GetNamedPipeClientProcessId(pipe, out pid);
    Console.WriteLine("Real client PID: {0}", pid);
