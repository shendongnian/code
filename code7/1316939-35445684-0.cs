    public static void AnotherFunction()
    {
        ArtnetReceiver((val) =>
        {
            // do work with the value returned
        });
    }
    
    public static void ArtnetReceiver(Action<string> callback)
    {
        artnet.NewPacket += (object sender, ArtNet.Sockets.NewPacketEventArgs<ArtNet.Packets.ArtNetPacket> e) =>
        {
            // some stuff going on...
    
            var dataout = value;
            callback(dataout);
        };
    }
