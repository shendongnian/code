	using System;
	using System.Net;
	public class Program
	{
		public void Main()
		{
			string remoteUri = "http://download.finance.yahoo.com/d/quotes.csv?s=%40%5EDJI,aapl&f=o&e=.csv";
            string fileName = "aapl.csv";
		
			using (var myWebClient = new WebClient())
			{
				myWebClient.DownloadFile(remoteUri, fileName);
			}	
		}
	}
