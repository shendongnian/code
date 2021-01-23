    Packet packet = PacketBuilder.Build(
        DateTime.Now,
        new EthernetLayer
        {
            Source = new MacAddress("00:50:56:a5:64:4d"),
            Destination = new MacAddress("00:50:56:9a:78:c7"),
            EtherType = EthernetType.Arp
        },
        new ArpLayer
        {
            ProtocolType = EthernetType.IpV4,
            SenderHardwareAddress = new byte[] {0x00, 0x50, 0x56, 0xa5, 0x64, 0x4d}.AsReadOnly(),
            SenderProtocolAddress = new byte[] {0x0a, 0xd8, 0x64, 0xd2}.AsReadOnly(),
            TargetHardwareAddress = new byte[] {0x00, 0x50, 0x56, 0x9a, 0x78, 0xc7}.AsReadOnly(),
            TargetProtocolAddress = new byte[] {0x0a, 0xd8, 0x64, 0xd3}.AsReadOnly(),
            Operation = ArpOperation.Reply,
        });
