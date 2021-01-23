    // Length, 4  
    // Type, 4  
    // Initiator GUID, 16  
    // Friendly Name, variable  
    // Protocol Version, 4  
    byte[] type = BitConverter.GetBytes(1);  
    Guid g = Guid.NewGuid();  
    byte[] guid = g.ToByteArray();  
    byte[] host = Encoding.UTF8.GetBytes("HostName\0");  
    byte[] version = BitConverter.GetBytes(1 << 16);  
    int len = 4 + type.Length + guid.Length + host.Length + version.Length;  
    byte[] length = BitConverter.GetBytes(len);  
    
    byte[] data = length.Concat(type).Concat(guid).Concat(host).Concat(version).ToArray();  
    
    s.Send(data);  
    
    byte[] responseLen = new byte[4];  
    int recvLen = s.Receive(responseLen, 4, SocketFlags.None);  
    len = BitConverter.ToInt32(responseLen, 0) - 4;  
    
    byte[] responseData = new byte[len];  
    recvLen = s.Receive(responseData, len, SocketFlags.None);  
