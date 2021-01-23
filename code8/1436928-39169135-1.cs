    [DllImport("ts3client_win32.dll", CallingConvention =   CallingConvention.Cdecl, EntryPoint = "ts3client_startConnection", CharSet = CharSet.Ansi)]
	public static extern uint ts3client_startConnection(uint64 arg0, string identity, string ip, uint port, string nick, string[] defaultchannelarray, string defaultchannelpassword, string serverpassword);
    ...
    string[] defaultarray = new string[] { "name", ""};
	/* Connect to server on localhost:9987 with nickname "client", no default channel, no default channel password and server password "secret" */
	error = ts3client.ts3client_startConnection(scHandlerID, identity, "localhost", 9987, "client", defaultarray, "password", "secret");
	if (error != public_errors.ERROR_ok) {
		Console.WriteLine("Error connecting to server: 0x{0:X4}", error);
		Console.ReadLine();
		return;
	}
