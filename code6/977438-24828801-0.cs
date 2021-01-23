	public IEnumerable<dynamic> GetResults(string id, int n) {
            
		WebRequest request = WebRequest.Create(baseurl + id + "/results");
		request.Headers.Add("Authorization", "Token " + token);
		WebResponse response = request.GetResponse();
		Stream responseStream = response.GetResponseStream();
		StreamReader sr = new StreamReader(responseStream);
		while(!sr.EndOfStream) {
			string line = sr.ReadLine();
			yield return Json.Decode(line);
		}
	}
