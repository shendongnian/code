     var httpResponseMessage = Request.CreateResponse();
            TokenResponse tokenResponse;
            bool wasAbleToGetAccesToken = _identityServerHelper.TryGetAccessToken(userLogin.Username, userLogin.Password,
                platform, out tokenResponse);
            httpResponseMessage.StatusCode = wasAbleToGetAccesToken ? HttpStatusCode.OK : HttpStatusCode.Unauthorized;
            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(tokenResponse),
                System.Text.Encoding.UTF8, "application/json");
            return httpResponseMessage;
