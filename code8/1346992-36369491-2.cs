    using System.Net.Http;
    using System.Threading.Tasks;
    using ModernHttpClient;
    ...
	public async Task<string> GetPlaylist()
	{
        // Use https to satisfy iOS ATS requirements.
		var client = new HttpClient(new NativeMessageHandler());
		var response = await client.GetAsync("https://api.soundcloud.com/playlists?client_id=17ecae4040e171a5cf25dd0f1ee47f7e&limit=1");
		var responseString = await response.Content.ReadAsStringAsync();
		return responseString;
	}
