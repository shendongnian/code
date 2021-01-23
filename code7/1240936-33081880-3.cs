	using System.Net;
	using HtmlAgilityPack;
	namespace ConsoleApplication5
	{
		class Program
		{
			static void Main(string[] args)
			{
				WebClient webClient = new WebClient();
				string page = webClient.DownloadString("http://www.deu.edu.tr/DEUWeb/Guncel/v2_index_cron.html");
				HtmlDocument doc = new HtmlDocument();
				doc.LoadHtml(page);
				HtmlNode table = doc.DocumentNode.SelectSingleNode("//table");
				foreach (var cell in table.SelectNodes("tr/td"))
				{
					string someVariable = cell.InnerText;
				}
			}
		}
	}
