        public void CallGooglePlacesAPIAndSetCallback(string websiteName)
        {
            using (var db = new WebAnalyzerEntities())
            {
                IList<IRecord> addressesToBeSearched = db.Rent.Where<IRecord>(o => o.Url.Contains(websiteName) && o.SpatialAnalysis.Count == 0).ToList().Union(db.Sale.Where<IRecord>(oo => oo.Url.Contains(websiteName) && oo.SpatialAnalysis.Count == 0)).ToList();
                foreach (var locationTobeSearched in addressesToBeSearched)
                {
                    try
                    {
               //this is where I introduced the lock
                        lock (_lock)
                        {
                            dynamic res = null;
                            using (var client = new HttpClient())
                            {
                                while (res == null || HasProperty(res, "next_page_token"))
                                {
                                    var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={locationTobeSearched.Address}&key={googlePlacesApiKey}&bounds=51.222,-11.0133788|55.636,-5.6582363";
                                    if (res != null && HasProperty(res, "next_page_token"))
                                        url += "&pagetoken=" + res["next_page_token"];
                                    var response = client.GetStringAsync(url).Result;
                                    JavaScriptSerializer json = new JavaScriptSerializer();
                                    res = json.Deserialize<dynamic>(response);
                                    if (res["status"] == "OK")
                                    {
                                        Tuple<decimal?, decimal?, string> coordinatesAndPostCode = ReadResponse(res["results"][0]);
                                        if (coordinatesAndPostCode != null && coordinatesAndPostCode.Item1.HasValue && coordinatesAndPostCode.Item2.HasValue)
                                        {
               //this is the line where exception was thrown
                                            locationTobeSearched.SpatialAnalysis.Add(new SpatialAnalysis() { Point = CreatePoint(coordinatesAndPostCode.Item1.Value, coordinatesAndPostCode.Item2.Value) });
                                            locationTobeSearched.PostCode = coordinatesAndPostCode.Item3;
                                        }
                                    }
                                    else if (res["status"] == "OVER_QUERY_LIMIT")
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    db.SaveChanges();
                }
            }
        }
