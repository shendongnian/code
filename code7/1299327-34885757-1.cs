		Client ParseData(string line)
		{
			Client client = new Client ();
			client.name = line.Substring (0, 10);
			// remove the client name
			line = line.Substring (10);
			while (line.Length > 0)
			{
				// create new item
				ClientData data = new ClientData ();
				data.code = line.Substring (0, 10);
				data.description = line.Substring (10, 50);
				client.data.Add (data);
				// next item in the line
				line = line.Substring (60);
			}
			return client;
		}
