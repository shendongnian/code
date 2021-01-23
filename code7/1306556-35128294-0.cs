     public void GetProperties()
    {
        new GameSparks.Api.Requests.GetPropertyRequest()
            .SetPropertyShortCode("GAME_SETTINGS")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    print(response.JSONString);
                    int androidProperty = (int)response.Property.GetInt("AppVersionAndroid");
                    int IOSProperty = (int)response.Property.GetInt("AppVersionIOS");
                    print("AndroidProperty:" + androidProperty);
                    print("IOSProperty:" + IOSProperty);
                }
                else
                {
                    Debug.LogWarning(response.JSONString);
                }
            });
    }
