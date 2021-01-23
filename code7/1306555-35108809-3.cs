    new GameSparks.Api.Requests.GetPropertyRequest().SetPropertyShortCode("GAME_SETTINGS").Send((response) => {
        if (!response.HasErrors) {
            Debug.Log("Setting Achieved: "+response.JSONString);
            //Serialization
            var info = JsonUtility.FromJson<RootObject>(response.JSONString);
            //Print the AppVersionIOS property
            Debug.Log("App Version iOS: " + info.Property.AppVersionIOS);
        } else {
            Debug.Log("Error Getting Settings");
        }
    });
