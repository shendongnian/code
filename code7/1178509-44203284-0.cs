    static void Main(string[] args)
            {
                string requestURL = @"http://www.example.co.uk/test/wp-json/wc/v1/products";
               
                UriBuilder tokenRequestBuilder = new UriBuilder(requestURL);
                var query = HttpUtility.ParseQueryString(tokenRequestBuilder.Query);
                query["oauth_consumer_key"] = "consumer_key";
                query["oauth_nonce"] = Guid.NewGuid().ToString("N");
                query["oauth_signature_method"] = "HMAC-SHA1";
                query["oauth_timestamp"] = (Math.Truncate((DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds)).ToString();
                string signature = string.Format("{0}&{1}&{2}", "POST", Uri.EscapeDataString(requestURL), Uri.EscapeDataString(query.ToString()));
                string oauth_Signature = "";
                using (HMACSHA1 hmac = new HMACSHA1(Encoding.ASCII.GetBytes("consumer_Secret&")))
                {
                    byte[] hashPayLoad = hmac.ComputeHash(Encoding.ASCII.GetBytes(signature));
                    oauth_Signature = Convert.ToBase64String(hashPayLoad);
                }
                query["oauth_signature"] = oauth_Signature;
                tokenRequestBuilder.Query = query.ToString();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(tokenRequestBuilder.ToString());
                request.ContentType = "application/json; charset=utf-8";
                // request.Method = "GET";
                request.Method = "POST";
    
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = File.ReadAllText(@"D:\JsonFile.txt");//File Path for Json String
    
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
    
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
