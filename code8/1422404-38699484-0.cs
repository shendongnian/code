    using(WebClient client = new WebClient())
            {
                NameValueCollection requestParameters = new NameValueCollection();
                requestParameters.Add("param1", "5");
                requestParameters.Add("param2", json);
                byte[] response = client.UploadValues("your url here", requestParameters);
                string responseBody = Encoding.UTF8.GetString(response);
            }
