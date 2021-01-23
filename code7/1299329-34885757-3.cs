        // this parser will read as many itens as there are in the line
        // and return a Client instance with those inside.
		public static class Parser
		{
			public static Client ParseData(string line)
			{
				Client client = new Client ();
				client.data = new List<ClientData> ();
				client.name = line.Substring (2, 10);
				// remove the client name
				line = line.Substring (12);
				while (line.Length > 0)
				{
					// create new item
					ClientData data = new ClientData ();
					data.code = line.Substring (2, 10);
					data.description = line.Substring (14, 50);
					client.data.Add (data);
					// next item
					line = line.Substring (64);
				}
				return client;
			}
		}
