        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)base.GetWebRequest(uri);
            request.Headers.Add("Auth-Token", this.authToken);
            return request;
        }
