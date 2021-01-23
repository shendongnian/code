    public async Task Load (string url)
		{
			try{
				using (var http = new HttpClient (new NativeMessageHandler ())) {
					var x = await http.GetAsync (new Uri (url));
					string res = await x.Content.ReadAsStringAsync ();
					MainViewModel.JsonList = JsonConvert.DeserializeObject<ArticleClass.RootObject> (res);
				}
			}catch (Exception ex) {
				MainViewModel.JsonList = null;
			}
		}
