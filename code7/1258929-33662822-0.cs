	List<Uri> uris=new List<Uri>(); //fill with uris
	var tasks = uris.Select(async (u, i)=>{
		await Task.Delay(TimeSpan.FromSeconds(i));
		using(var wc = new WebClient())
		{
			return await wc.DownloadStringTaskAsync(u);
		}
	});
	var results = await Task.WhenAll(tasks);
