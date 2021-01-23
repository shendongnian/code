    [HttpPost]
        public async Task<MyResponse> VerifyAsync(MyModel model)
        {
            var MyServer = ConfigurationManager.AppSettings["MyServer"];
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
        
            var requestUri = string.Format(@"http://{0}/api/VerifyMyModel/PostAsync", MyServer);
        
            using (var c = new HttpClient())
            {
                var response = await c.PostAsJsonAsync(requestUri, json);
            }
            ...
        }
