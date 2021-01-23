	const string ntpServer = "pool.ntp.org";
	const int timeout = 2000;
	var ntpData = new byte[48];           
	ntpData[0] = 0x1B; //LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)       
	IPHostEntry dnsLookup = null;
	try {
		dnsLookup = Dns.GetHostEntry(ntpServer);
	}
	catch(Exception e){ //Better to catch specific types of exceptions
		Label1.Text = string.Format("Unable to resolve hostname: {0}, ntpServer)";
	}
	if (dnsLookup == null || dnsLookup.AddressList.Length == 0){
		return;
	}
	var ipEndPoint = new IPEndPoint(dnsLookup.AddressList[0], 123);
	var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,  ProtocolType.Udp);    
	// wait two seconds before timing out
	socket.ReceiveTimeout = timeout; 
	
	try{
    	socket.Connect(ipEndPoint);
	    socket.Send(ntpData);
	
        socket.Receive(ntpData);
		ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
		ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];
		var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
		var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);
		Label1.Text = networkDateTime.ToString();
	}
	catch(Exception e){ //Better to catch specific types of exceptions
		Label1.Text = string.Format("Unable to get time from NTP server: {0}, ntpServer)";
	}
	finally(){
		socket.Close();
	}
