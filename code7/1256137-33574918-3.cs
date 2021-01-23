    public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
    {
        string pipeAccess = String.Format(@"\\.\pipe\{0}", Program.pipeGuid);
    
        IntPtr pipe = CreateFile(pipeAccess, FileAccess.ReadWrite,
            0, IntPtr.Zero, FileMode.Open, FileAttributes.Normal, IntPtr.Zero);
    
        uint pid = 0;
        GetNamedPipeClientProcessId(pipe, out pid);
        Console.WriteLine("Real client PID: {0}", pid);
    
        return _encoder.ReadMessage(buffer, bufferManager, contentType);
    }
