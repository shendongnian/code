    public async Task<String> GetAccessToken()
        {
            try
            {
                public Const string url="Enter the Url without parameters";
                var ParmetersToPass = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string,string>("username",//+YourUserNameVariable),
                    new KeyValuePair<string,string>("password",//+YourPassWordVariable),
                    new KeyValuePair<string,string>("grant_type",password),
                };
                var httpClient = new HttpClient(new HttpClientHandler());
                HttpResponseMessage response = await httpClient.PostAsync(url, new FormUrlEncodedContent(ParmetersToPass));
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                //I hope You are recieving a json response from server side if so add reference 'Newton soft Json' fron 'nuget' to project
                dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(responseString);
                string status = obj["status"].ToString();
                string access_token = string.Empty();
                if (status == //True,yes or compare with string that indicate request is sucess)
                {
                    //Code to parse access token, a sample is given bellow 
                    access_token=obj["access_token"].ToString(); 
                }
                return access_token
            }
            catch (Exception ex)
            {
                Debug.WriteLine(">> An error occured" + ex.Message);
                return string.Empty();
            }
        }
