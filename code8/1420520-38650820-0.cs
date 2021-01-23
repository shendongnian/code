                    using (var client = new WebClient())
                {
                    string url = currentURL + "resources?AUTHTOKEN=" + pmtoken;
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Encoding = System.Text.Encoding.UTF8;
                    string serialisedData = JsonConvert.SerializeObject(data);
                    string response = client.UploadString(url, serialisedData);
                }
