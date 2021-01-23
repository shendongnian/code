    Console.WriteLine("Restarting SSHD service on modem...");
	try
	{
	    var client = new SshClient(IPAddress, "root", "PASSWORD")
		client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(10);
		client.Connect();
		client.RunCommand("service sshd restart >/dev/null 2>&1 &");
	    Console.WriteLine("\tSuccess");
	}
	catch (System.Net.Sockets.SocketException)
	{
	    //We got disconnected because we just restarted the sshd service
	    //This is expected
	    Console.WriteLine("\tSuccess");
	}
	catch
	{
	    //We got disconnected for some other reason
	    Console.WriteLine("\tIt appears there was a problem restarting the sshd service");
	}
