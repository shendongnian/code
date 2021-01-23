	public class WebSitePing
	{
		public void Ping()
		{
			var lstWebSites = new List<string>
				{
					"www.mearstransportation.com",
					"www.amazon.com",
					"www.ebay.com",
					"www.att.com",
					"www.verizon.com",
					"www.sprint.com",
					"www.centurylink.com",
					"www.yahoo.com"
				};
			foreach (string website in lstWebSites)
			{
				var roundTripTime = new List<long>();
				for (var i = 0; i < 4; i++)
				{
					using (var myPing = new Ping())
					{
						var reply = myPing.Send(website, 1000);
						if (reply != null)
						{
							roundTripTime.Add(reply.RoundtripTime);
						}
					}
				}
				Console.WriteLine("{0}, {1}", website, String.Join(", ", roundTripTime));
			}
		}
	}
