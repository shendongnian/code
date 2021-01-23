	// Extract a device from the list
	ICaptureDevice device = devices[i];
	// Open the device for capturing
	int readTimeoutMilliseconds = 1000;
	device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
	Console.WriteLine();
	Console.WriteLine("-- Listening on {0}...",
	    device.Description);
	Packet packet = null;
	// Keep capture packets using GetNextPacket()
	while((packet=device.GetNextPacket()) != null )
	{
	    // Prints the time and length of each received packet
	    DateTime time = packet.PcapHeader.Date;
	    int len = packet.PcapHeader.PacketLength;
	    Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
	        time.Hour, time.Minute, time.Second,
	        time.Millisecond, len);
	}
	// Close the pcap device
	device.Close();
	Console.WriteLine(" -- Capture stopped, device closed.");
