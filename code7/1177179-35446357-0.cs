        public async Task<ActionResult> Connect()
        {
            var clientId = "xxxxx";
            var clientSecret = "xxxxxx";
            var redirectUri = new Uri("http://localhost:xxxx/Home/AuthCallBackAsync");//Your call back URL
            var config = new BoxConfig(clientId, clientSecret, redirectUri);
            return Redirect(config.AuthCodeUri.ToString());
        }
   
