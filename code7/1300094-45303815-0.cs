    private static byte[] CreateConnectPacketOPP(int maxClientPacketSize)
    {
        int packetSize = 7;
        byte[] theConnectPacket = new byte[packetSize];
        int offset = 0;
        theConnectPacket[offset++] = 0x80;                       // Connect
        theConnectPacket[offset++] = (byte)((packetSize & 0xFF00) >> 8);       // Packetlength Hi Byte
        theConnectPacket[offset++] = (byte)(packetSize & 0xFF);                    // Packetlength Lo Byte
        theConnectPacket[offset++] = 0x10;                       // Obex v1
        theConnectPacket[offset++] = 0x00;                       // No flags
        theConnectPacket[offset++] = (byte) ((maxClientPacketSize & 0xFF00) >> 8);    // 2048 byte client max packet size Hi Byte
        theConnectPacket[offset++] = (byte) (maxClientPacketSize & 0xFF);                    // 2048 byte max packet size Lo Byte    
        return theConnectPacket;
    }
