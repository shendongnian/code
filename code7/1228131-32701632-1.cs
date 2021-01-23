    IntPtr ptrByteArray = Dde.DdeAccessDataString(da, out datasize);
    byte[] data = new byte[datasize];
    for(int i =0; i < datasize; i++)
    {
        data[i] = Marshal.ReadByte(ptrByteArray, i);
    }
    string result = System.Text.Encoding.ASCII.GetString(data);
