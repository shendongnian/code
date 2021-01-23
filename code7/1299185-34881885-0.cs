        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var req = actionContext.Request;
            if (!req.Headers.Contains("x-key") || req.Headers.GetValues("x-key") == null)
            {
                HttpResponseMessage responseMessage = new HttpResponseMessage()
                {
                    Content = new StringContent("{\"message\":\"Unauthorized\", \"payload\":\"\",\"response\":\"401\"}")
                };
                responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                actionContext.Response = responseMessage;
            }
        }
