    public async Task<bool> Login(string userName, string password)
    {
        LoginRequest loginRequest = new LoginRequest() { UserName = userName, Password = password };
        try
        {
            var loginResult = await _service.InvokeApiAsync("EasyParkLogin", JToken.FromObject(loginRequest));
            JObject json = JObject.Parse(loginResult.ToString());
            _service.CurrentUser = new MobileServiceUser(json["user"]["userId"].ToString().Replace("EasyPark:", ""))
            {
                MobileServiceAuthenticationToken = json["authenticationToken"].ToString()
            };
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
