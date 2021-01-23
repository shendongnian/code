			//BigCommerce Authorization//
			string clientID = "grmx4ghnscp8pz2jb4bf2qylt9b61yh";
			string clientSecret = "ibjh6whikzab0jm84zgjw5uydstx1b8";
			string token = "d56i5khv6l4kgcd9k92wpavyh93iqh";
			string storeHash = "pdcnmnye";
			string resourcePath = "products";
			string baseURL = "https://api.bigcommerce.com/stores/" + storeHash + "/v2/" + resourcePath;
			string requestParams = "?min_id=65&max_id=75";
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseURL + requestParams);
			req.AllowAutoRedirect = true;
			req.ContentType = "application/json";
			req.Accept = "application/json";
			req.Method = "GET";
			//string authValue = Convert.ToBase64String(Encoding.Default.GetBytes("admin:" + ""));
			req.Headers.Add("X-Auth-Client", clientID);
			req.Headers.Add("X-Auth-Token", token);
			//req.Headers.Add("Authorization", authValue);
			Trace.Write("Base URL",baseURL);
			string jsonResponse = null;
			using (WebResponse resp = req.GetResponse()) {
				if (req.HaveResponse && resp != null) {
					using (var reader = new StreamReader(resp.GetResponseStream())) {
						jsonResponse = reader.ReadToEnd();
					}
				}
			}
			Response.Write(jsonResponse); 
