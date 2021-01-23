    public string GetAccessToken()
        {
                SpotifyToken token = new SpotifyToken();
                string url5 = "https://accounts.spotify.com/api/token";
                var clientid = "your_client_id";
                var clientsecret = "your_client_secret";
    
                //request to get the access token
                var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));
    
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);
    
                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Accept = "application/json";
                webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);
    
                var request = ("grant_type=client_credentials");
                byte[] req_bytes = Encoding.ASCII.GetBytes(request);
                webRequest.ContentLength = req_bytes.Length;
    
                Stream strm = webRequest.GetRequestStream();
                strm.Write(req_bytes, 0, req_bytes.Length);
                strm.Close();
    
                HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                String json = "";
                using (Stream respStr = resp.GetResponseStream())
                {
                    using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                    {
                        //should get back a string i can then turn to json and parse for accesstoken
                        json = rdr.ReadToEnd();
                        rdr.Close();
                    }
                }
         return token.access_token;
    }
