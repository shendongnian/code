    public static void Main(string[] args) {
    	// Setup and initialize Open.NAT:
    	NatUtility.PortMapper = Upnp; // Search only for Upnp devices
    	NatUtility.TraceSource.Switch.Level = SourceLevels.Information;
    	NatUtility.DeviceFound += DeviceFound;
    	NatUtility.Initialize();
    
    	// Start looking for UPnP devices:
    	NatUtility.StartDiscovery();
    
    	while(true) {}
    }
    
    // This method is called every time a new UPnP device is found:
    private static async void DeviceFound (object sender, DeviceEventArgs args) {
    	var deviceIP = await device.GetExternalIPAsync();
    	Console.WriteLine("Found a UPnP device with IP " + deviceIP);
    	Console.WriteLine("Attempting to map UDP port 1600...");
    	await device.CreatePortMapAsync(new Mapping(Protocol.Udp, 1600, 1600, 10000, "Open.Nat Testing"));
    }
