    private FacebookAuthorizationResponse AuthorizeUser(FacebookClient client, string userId, string accessToken)
    {
        dynamic expirationToken = client.Get("debug_token", new
                                                                {
                                                                    input_token = accessToken,
                                                                    access_token = _appAccessToken
                                                                });
        DateTime expiresAt = DateTimeConvertor.FromUnixTime(expirationToken.data.expires_at);
        bool isValid = expirationToken.data.is_valid;
        if (!isValid)
        {
            return new FacebookAuthorizationResponse
                        {
                            IsAuthorized = false,
                        };
        }
        dynamic response = client.Get(userId, new
                                                    {
                                                        access_token = accessToken,
                                                        fields = "id,name"
                                                    });
        return new FacebookAuthorizationResponse
                    {
                        IsAuthorized = isValid,
                        ExpiresAt = expiresAt,
                        Name = response.name
                    };
    }
