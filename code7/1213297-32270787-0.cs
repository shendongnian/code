    	    var mCountryUrl = new Uri("http://xxxxxxx.wwww/restservice/country");
			var mList = new List<string>();
			var mCountry = new List<Country>();
			WebClient client = new WebClient();
			var data = client.DownloadData(mCountryUrl);
			string json = Encoding.UTF8.GetString(data);
			mCountry = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Country>>(json);
			Console.WriteLine(mCountry.Count.ToString());
			int x = mCountry.Count;
			for (int i = 0; i < x; i++)
			{
				mList.Add(mCountry[i].name);
			}
			return mList;
