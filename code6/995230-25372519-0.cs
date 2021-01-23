        const string COMMAND_OFF = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>0</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
		const string COMMAND_ON = @"<?xml version=""1.0"" encoding=""utf-8""?><s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><s:Body><u:SetBinaryState xmlns:u=""urn:Belkin:service:basicevent:1""><BinaryState>1</BinaryState></u:SetBinaryState></s:Body></s:Envelope>";
		public void On (string iP, string port)
		{
			SendCommand (COMMAND_ON, iP, port); 
		}
		public void Off (string iP, string port)
		{
			SendCommand (COMMAND_OFF, iP, port);
		}
		private void SendCommand (string command, string iP, string port)
		{
			string targetUrl = "http://" + iP + ":" + port + "/upnp/control/basicevent1";
		
			//  Create the packet and payload to send to the endpoint to get the switch to process the command
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create (targetUrl);
			request.Method = "POST";
			request.Headers.Add ("SOAPAction", "\"urn:Belkin:service:basicevent:1#SetBinaryState\"");
			request.ContentType = @"text/xml; charset=""utf-8""";
			request.KeepAlive = false;
			Byte[] bytes = UTF8Encoding.ASCII.GetBytes (command);
			request.ContentLength = bytes.Length;
			using (Stream stream = request.GetRequestStream ()) {
				stream.Write (bytes, 0, bytes.Length);
				stream.Close ();
				request.GetResponse ();
			}
			
			//  HACK: If we don't abort the result the device holds on to the connection sometimes and prevents other commands from being received
			
			request.Abort ();
		}
		public void GetDevice (string Name, wemoAction action)
		{
			try {
				Client client = new Client ();
				client.BrowseAll (); //Browse all available upnp devices
				client.DeviceAdded += (sender, e) => { //do something when a device is found
					System.Console.WriteLine ("got one!");
					if (e.Device.ToString ().Contains ("urn:Belkin")) {
						if (e.Device.GetDevice ().FriendlyName.Equals (Name)) {
							var url = e.Device.GetDevice ().Services.First ().EventUrl;
							switch (action) {
							case wemoAction.on:
								On (url.DnsSafeHost, url.Port.ToString ());
								break;
							case wemoAction.off:
								Off (url.DnsSafeHost, url.Port.ToString ());
								break;
							}
						}
					}
				};
			} catch (Exception ex) {
				System.Console.WriteLine (ex.Message);
			}
		}
