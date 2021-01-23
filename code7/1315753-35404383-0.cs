    public void InitialiseVenemaComms()
    {
	    string initMessage = null;
	    DebugInfo(1, "*** InitialiseVenemaComms");
	    initMessage = "002" + StationPrms.StationId + "ACK";
	try
	{
		System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient(Convert.ToInt32(StationPrms.Venema.LocalPort));
		byte[] messageBytes = System.Text.Encoding.ASCII.GetBytes(initMessage);
		udpClient.Connect(StationPrms.Venema.DNS, Convert.ToInt32(StationPrms.Venema.RemotePort));
		DebugInfo(1, string.Format("*** Sending init message '{0}' from port '{1}' to ip '{2}' on port '{3}'", initMessage, StationPrms.Venema.LocalPort, StationPrms.Venema.DNS, StationPrms.Venema.RemotePort));
		udpClient.Send(messageBytes, messageBytes.Length);
		udpClient.Close();
		DebugInfo(1, "*** Init Message Sent");
	}
	catch (Exception ex)
	{
		DebugInfo(2, "Error: " + ex.Message);
		CssError("Error initalising Venema comms: " + ex.Message);
	}
