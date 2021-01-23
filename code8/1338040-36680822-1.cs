    private void PacketHandler(Packet packet)
    {
        string sourceMac = packet.Ethernet.Source.ToString();
        string destinationMac = packet.Ethernet.Destination.ToString();
        //--more code
    }
