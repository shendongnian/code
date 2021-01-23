     Guid testGuid = guid.empty;
     using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(testData.customerAccountURL).Result;
                if (response.IsSuccessStatusCode)
                {
                    string JSONResponse = response.Content.ReadAsStringAsync().Result;
                    var rObjects = JsonConvert.DeserializeObject<List<myclass>>(JSONResponse);
                    testGuid = Guid.Parse(rObjects.First().field1.ToString());
                    // now use this guid to search for a customer
                }
                string GuidURL = URL + "/"+ testGuid;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(GuidURL);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                    string data = values.ElementAt(0).Value;
                }
            }
