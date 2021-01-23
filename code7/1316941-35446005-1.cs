    //note the return type - it's void!
    public void OnArtNet_NewPacket(object sender, ArtNet.Sockets.NewPacketEventArgs<ArtNet.Packets.ArtNetPacket> e)
    {
    string dataout; //included here so the sample will compile
    if (e.Packet.OpCode == ArtNet.Enums.ArtNetOpCodes.Dmx)
            {
                var packet = e.Packet as ArtNet.Packets.ArtNetDmxPacket;
                Console.Clear();
    
                if (packet.DmxData != _dmxData)
                {
                    for (var i = 0; i < packet.DmxData.Length; i++)
                    {
                        if (packet.DmxData[i] != 0)
                        {
                        }
    
                        int temp = i + 1;
                        string chanNum = temp.ToString();
                        string chanValue = packet.DmxData[i].ToString();
    
                        dmxString.Add(chanNum + "-" + chanValue);
                    };
    
                    //dmx stuff
    
                    dataout = string.Join(",", dmxString.ToArray());
                    dmxOut = dataout;
                    //Console.WriteLine(dataout);//works here
    
                    _dmxData = packet.DmxData;
                }
            }
    }
