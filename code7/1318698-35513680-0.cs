        private Packet ChangePacketIp(Packet packet)
        {
                EthernetLayer ethernetLayer = ...
                // Check whether the packet is ipv4 packet.
                if (ethernetLayer.EtherType == EthernetType.IpV4)
                {
                    DateTime packetTimestamp = ...
                    TransportLayer transportlayer = ...
                    ILayer datagramLayer = ...
                    IpV4Layer ipV4Layer = ...
                    if (packet.Ethernet.IpV4.Source.ToString() == OriginalIpAddress)
                        ipV4Layer.Source = new IpV4Address(NewIpAddress);
                    else if (packet.Ethernet.IpV4.Destination.ToString() == OriginalIpAddress)
                        ipV4Layer.CurrentDestination = new IpV4Address(NewIpAddress);
                    ipV4Layer.HeaderChecksum = null;
                    if (transportlayer == null)
                        return PacketBuilder.Build(packetTimestamp, ethernetLayer, ipV4Layer, datagramLayer);
                    else
                    {
                        transportlayer.Checksum = null;
                        ILayer payload = packet.Ethernet.IpV4.Transport.Payload.ExtractLayer();
                        return PacketBuilder.Build(packetTimestamp, ethernetLayer, ipV4Layer, transportlayer, payload);
                    }
                }
                else
                    return packet;
        }
