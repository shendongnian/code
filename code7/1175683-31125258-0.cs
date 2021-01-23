	public async Task<List<string>> GetNumbers()
	{
		// Getting the number of microseconds since Jan 1st, 1970
		var microseconds = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0))).TotalMilliseconds;
		// Creating the webrequest and passing the parameter
		var request =
			WebRequest.CreateHttp(
				string.Format(
					"http://www1.caixa.gov.br/loterias/loterias/megasena/megasena_pesquisa_new.asp?app={0}",
					microseconds));
		// Adding a cookie container otherwise you will be stuck in a redirect loop
		var jar = new CookieContainer();
		request.CookieContainer = jar;
		try
		{
			var response = await request.GetResponseAsync();
			using (var sr = new StreamReader(response.GetResponseStream()))
			{
				var html = await sr.ReadToEndAsync();
				var document = new HtmlAgilityPack.HtmlDocument();
				document.LoadHtml(html);
				var nodes = document.DocumentNode.SelectNodes("//span [@class=\"num_sorteio\"]");
				var numbersNodes = nodes.Last().SelectNodes("//li");
				// selecting the last 6 nodes that represent the "Números Sorteados" numbers
				return numbersNodes.Select(node => node.InnerText).Skip(6).ToList();
			}
		}
		catch (Exception e)
		{
			// very basic exception handling.
			Console.WriteLine(e);
		}
		return null;
	} 
