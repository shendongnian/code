    async void Main()
    {
    	using (var handler = new HttpClientHandler())
    	{
    		handler.AutomaticDecompression = DecompressionMethods.GZip;
    		using (HttpClient client = new HttpClient(handler))
    		{
    			var result = await client.GetStringAsync("http://www.tsetmc.com/tsev2/data/instinfodata.aspx?i=59266699437480384&c=64");
    			result.Dump();
    		}
    	}
    }
