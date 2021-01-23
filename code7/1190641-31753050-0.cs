        public HttpResponseMessage Get()
        {
            var content = new JavaScriptSerializer().Serialize(new { foo = "bar" });
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
            response.Headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromSeconds(15)
            };
            return response;
        }
    // returns in the response: "Cache-Control: public, max-age=15"
