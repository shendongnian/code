        [HttpPost]
        [album]
        public ActionResult Contact2(string one, string two)
        {
            var req = this.Request;
            var res = this.Response;
            UriBuilder uriBuilder = new UriBuilder("http://" + req.Url.Authority + req.Url.LocalPath);
            NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Add("album", "first");
            uriBuilder.Query = query.ToString();
            string url = req.Url.AbsolutePath.ToString();
            return this.Redirect(uriBuilder.Uri.OriginalString);            
        }
