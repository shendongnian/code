    public static async Task RootObjectRS MakeRequestAsync(string requestUrl, SeneruUBT.Models.TokenModels token, string triptype, string from, string to, string flyin, string flyout, string flyclass, string passengers, DateTime starting, int reqstid)
        {
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization", token.token_type + " " + token.access_token);
            request.Accept = "application/json";
            string ttrip = triptype;
            var streamWriter = new StreamWriter(await request.GetRequestStreamAsync());
            if (ttrip.Equals("OneWay"))
            {
                RootObject searchBFMRQO = CreateRequestObjectOneWay(triptype, from, to, flyin, flyclass, passengers);
                String searchString = JsonConvert.SerializeObject(searchBFMRQO);
                streamWriter.Write(JsonConvert.SerializeObject(searchBFMRQO));
                streamWriter.Flush();
            }
            HttpWebResponse response = await (HttpWebResponse)request.GetResponseAsync();
            var httpResponse = await (HttpWebResponse)request.GetResponseAsync();
            int sc = (int)httpResponse.StatusCode;
            System.Diagnostics.Debug.Write(sc);
            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(await httpResponse.GetResponseStreamAsync()))
                {
                    var result = streamReader.ReadToEnd();
                    RootObjectRS errorresult = JsonConvert.DeserializeObject<RootObjectRS>(result);
                    return (errorresult);
                }
            }
            else
            {
                var resp = new StreamReader(await httpResponse.GetResponseStreamAsync()).ReadToEnd();
                RootObjectRS searchResponse = JsonConvert.DeserializeObject<RootObjectRS>(resp.ToString());
                SearchResponseFlightService ResponsFlSer = null;
                ResponsFlSer = new SearchResponseFlightService(new UBTRepository.UBTUnitofWorks(new UBTRepository.TravelEntities()));
                SearchResponseFlight ReFl = new SearchResponseFlight();
                ReFl.searchRequestID = reqstid;
                ReFl.StopQuantity = "1";
                ReFl.responseJson = resp.ToString();
                DateTime ending = DateTime.Now;
                ReFl.responseDuration = ending.Subtract(starting).Milliseconds;
                ReFl.starttimestamp = starting;
                ReFl.endtimestamp = ending;
                ResponsFlSer.Add(ReFl);
                searchResponse.reqid = reqstid;
                return (searchResponse);
            }
        }
