    int interruptCount;    
    using (FileStream f = new FileStream("/dev/uioX", FileMode.Open, FileAccess.Read, FileShare.Read))
    {
        byte[] buffer = new byte[4];
        int bytesRead = f.Read(buffer, 0, buffer.Length);
        if (bytesRead != buffer.Length)
        {
            throw new InvalidOperationException("Expected " + buffer.Length + " bytes but got " + bytesRead);
        }
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(buffer);
        }
        interruptCount = BitConverter.ToInt32(buffer, 0);
    }
