    string Message = Console.ReadLine();
    byte[] buff = Encoding.UTF8.GetBytes(Message);
    
    // Problem: instead of the length of the string, the size of byte array must be used
    // because the UTF-8 encoding is used: generally, string length != "encoded number of bytes".
    byte size = (byte)Message.Length;
    ns.WriteByte(size);
    ns.Write(buff, 0, buff.Length);
    ns.Flush();
