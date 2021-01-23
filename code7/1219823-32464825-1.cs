    public void HandlePacket(Packet packet)
    {   
        if (packet is MessagePacket)
        {
            HandleMessagingPacket((MessagePacket)packet);
        }
        else if (pingPacket is PingPacket)
        {
            HandlePingPacket((PingPacket)packet);
        }
        else if ...
    }
