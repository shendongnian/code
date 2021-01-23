	static public async Task<bool> createPhotoThree(string imgName, byte[] imgData) {
		var httpClientRequest = new HttpClient();
		var postData = new Dictionary<string, object>();
		postData.Add("photo_name", imgName);
		postData.Add("photo_data", imgData);
		var jsonRequest = JsonConvert.SerializeObject(postData);
		HttpContent content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
		var result = await httpClientRequest.PostAsync("http://myadress.com/test.php", content);
		var resultString = await result.Content.ReadAsStringAsync();
		return true;
	}
