    Image DownloadImage(string fromUrl)
    {
    	using (System.Net.WebClient webClient = new System.Net.WebClient())
    	{
    		using (Stream stream = webClient.OpenRead(fromUrl))
    		{
    			return Image.FromStream(stream);
    		}
    	}
    }
