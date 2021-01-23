        string baseurl = "http://developer.echonest.com/api/v4/artist/profile?api_key=[API KEY]&name=weezer";
        var req = (HttpWebRequest) WebRequest.Create(baseurl);
        req.Method = WebRequestMethods.Http.Get;
        req.Accept = "application/json";
        using (var response = (HttpWebResponse) req.GetResponse())
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        responseString = sr.ReadToEnd();
                    }
                    var remaining = GetRateInfo(response.Headers, "X-RateLimit-Remaining");
                    var used = GetRateInfo(response.Headers, "X-RateLimit-Used");
                    var limit = GetRateInfo(response.Headers, "X-RateLimit-Limit");
                    Trace.WriteLine($"Excedeed EchoNest Limits: remaining {remaining} - used {used} - limit {limit}");
                }
            }
            else
            {
                // Error handling
            }
