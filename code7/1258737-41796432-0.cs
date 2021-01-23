    [HttpGet]
        [Route("A_Test")]
        public HttpResponseMessage A_Test()
        {
            HttpResponseMessage response;
            try
            {
                string regId = "";
                string profile = "<Name of Security Profile>";
                string msg = "Test";
                string data = "{ \"tokens\":[],\"send_to_all\":" + "true" + ",\"profile\":\"" + profile + "\",\"notification\":{\"message\":\"" + msg + "\"}}";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.ionic.io/push/notifications");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("X-Ionic-Application-Id", "<Ionic App ID>");
                    var keyBase64 = "Bearer " + "<Security Token>";
                    client.DefaultRequestHeaders.Add("Authorization", keyBase64);
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.ionic.io/push/notifications");
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response = client.SendAsync(request).Result;
                }
                return response;
            }
            catch (Exception ex)
            {
                response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                response.Content = new ObjectContent(typeof(string), ex.Message, new JsonMediaTypeFormatter(), "application/json");
                return response;
            }
        }
