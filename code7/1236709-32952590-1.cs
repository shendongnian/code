    [HttpPost]
    public AppIdentityToken CreateAndValidateIdentityToken(JObject data)
        {
            JToken userIdentityToken = data.GetValue("userIdentityToken");
            string rawToken = userIdentityToken.Value<string>();
            try
            {
                AppIdentityToken token = (AppIdentityToken)AuthToken.Parse(rawToken);
                token.Validate(new Uri("https://localhost:44300/AppRead/Home/Home.html"));
                return token;
            }
            catch (TokenValidationException ex)
            {
                throw new ApplicationException("A client identity token validation error occurred.", ex);
            }
        }
