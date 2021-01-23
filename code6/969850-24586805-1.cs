    byte[] packet =  CreateMessage(21,32,43,55,75,73,12,14,12);
    //send message
    //recv message and get ints back
    int[] ints =  GetParameters(packet);
....
    public byte[] CreateMessage(params int[] parameters)
    {
        var buf = new byte[parameters.Length * sizeof(int)];
        for (int i = 0; i < parameters.Length; i++) 
            Array.Copy(BitConverter.GetBytes(parameters[i]), 0, buf, i * sizeof(int), sizeof(int));
        return buf;
    }
    public int[] GetParameters(byte[] buf)
    {
        var ints = new int[buf.Length / sizeof(int)];
        for (int i = 0; i < ints.Length; i++)
            ints[i] = BitConverter.ToInt32(buf, i * sizeof(int));
        return ints;
    }
