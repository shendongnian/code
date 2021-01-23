         //some demo uri
         Uri uri = new Uri("https://api.datamarket.azure.com/Bing/Search/Composite?Sources=%27web%27&Query=%27xbox%27&$format=json");
         System.Net.WebRequest req = System.Net.WebRequest.Create(uri);
         byte[] byteKey = System.Text.ASCIIEncoding.ASCII.GetBytes(bingKey + ":" + bingKey);
         string stringKey = System.Convert.ToBase64String(byteKey);
         req.Headers.Add("Authorization", "Basic " + stringKey);
         req.Proxy = new System.Net.WebProxy("proxy_url", true);
         req.Proxy.Credentials = new NetworkCredential("", "", "");
         System.Net.WebResponse resp = req.GetResponse();
