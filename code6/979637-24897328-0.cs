    // NetworkStream ns; <-- already set up
    using(MemoryStream memory = new MemoryStream())
    using(BinaryWriter writer = new BinaryWriter(memory))
    {
        // all output to writer goes here
        // now close the envelop and send it:
        byte[] dataBuffer, sizeBuffer;
        dataBuffer = memory.ToArray();
        sizeBuffer = BitConverter.GetBytes(dataBuffer.Length);
        ns.SendBytes(sizeBuffer, 0, 4); // send message length (32 bit int)
        ns.SendBytes(dataBuffer, 0, dataBuffer.Length); // send message data
    }
