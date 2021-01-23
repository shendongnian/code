     private static byte[] CreateConnectPacketOPP(int maxPacketSize)
    {
        int packetSize = 7;
        byte[] theConnectPacket = new byte[packetSize];
    
        int offset = 0;
        ConnectPacket[offset++] = 0x80;                       // Connect
        ConnectPacket[offset++] = (byte)((packetSize & 0xFF00) >> 8);       // Packetlength Hi Byte
        ConnectPacket[offset++] = (byte)(packetSize & 0xFF);                    // Packetlength Lo Byte
        ConnectPacket[offset++] = 0x10;                       // Obex v1
        ConnectPacket[offset++] = 0x00;                       // No flags
        ConnectPacket[offset++] = (byte) ((maxPacketSize & 0xFF00) >> 8);    // 2048 byte client max packet size Hi Byte
        ConnectPacket[offset++] = (byte) (maxPacketSize & 0xFF);                    // 2048 byte max packet size Lo Byte    
    
        return ConnectPacket;
    }
