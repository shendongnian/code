	using System;
	using System.Net;
	public class Program
	{
		public void Main()
		{
			string remoteUri = "http://download.finance.yahoo.com/d/quotes.csv?s=%40%5EDJI,aapl&f=o&e=.csv";
		
			using (var myWebClient = new WebClient())
			{
				string csv = myWebClient.DownloadString(remoteUri);
				Console.WriteLine(csv);
			}	
		}
	}
