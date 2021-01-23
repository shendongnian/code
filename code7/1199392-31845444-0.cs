    private byte[] RCON_Command(string Command, int ServerData)
    {
        byte[] commandBytes = System.Text.Encoding.Default.GetBytes(Command);
        byte[] Packet = new byte[13 + commandBytes.Length + 1];
        for (int i = 0; i < Packet.Length; i++)
        {
            Packet[i] = (byte)0;
        }
        int index = 0;
        //Packet Size (Integer)
        byte[] bytes = BitConverter.GetBytes(Command.Length + 9);
        foreach (var byt in bytes)
        {
            Packet[index++] = byt;
        }
        //Request Id (Integer)
        bytes = BitConverter.GetBytes((int)0);
        foreach (var byt in bytes)
        {
            Packet[index++] = byt;
        }
        //SERVERDATA_EXECCOMMAND / SERVERDATA_AUTH (Integer)
        bytes = BitConverter.GetBytes(ServerData);
        foreach (var byt in bytes)
        {
            Packet[index++] = byt;
        }
        foreach (var byt in commandBytes)
	    {
            Packet[index++] = byt;
        }
        return Packet;
    }
