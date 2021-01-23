	private async System.Threading.Tasks.Task<string> LoadTermineAsync(HttpWebRequest myRequest)
	{
		using (var client = new HttpClient()) {
			using (var request = new HttpRequestMessage(HttpMethod.Get, myRemoteUrl)) {
				var response = await client.SendAsync(request).ConfigureAwait(false);
				var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
				return result;
			}
		}
	}
