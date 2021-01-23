    void UpdateStatus (object sender, EventArgs e)
		{
			Console.WriteLine(Reachability.RemoteHostStatus ().ToString());
			Console.WriteLine(Reachability.InternetConnectionStatus ().ToString());
			Console.WriteLine(Reachability.LocalWifiConnectionStatus ().ToString());
		}
