        [Authorize]
        [HttpGet, Route("api/{*url}")]
        public HttpResponseMessage Get(string url)
        {
            WindowsIdentity wi = null;
            wi = (WindowsIdentity)HttpContext.Current.User.Identity;
            using (wi.Impersonate())
            {
                var baseAddress = ConfigurationManager.AppSettings["BaseAddress"] + "/" + url;
                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                    http.Accept = "application/json; charset=utf-8";
                    http.ContentType = "application/json; charset=utf-8";
                    http.Method = "GET";
                    http.UseDefaultCredentials = true;
                    try
                    {
                        var response = http.GetResponse();
                        var stream = response.GetResponseStream();
                        var sr = new StreamReader(stream);
                        var contentResponse = sr.ReadToEnd();
                        return Request.CreateResponse(JsonConvert.DeserializeObject<Object>(contentResponse));
                    }
                    catch (Exception ex)
                    {
                         return Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
            }
        }
