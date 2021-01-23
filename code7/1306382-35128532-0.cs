     new GameSparks.Api.Requests.DeviceAuthenticationRequest()
    .SetDeviceId(deviceId)
    .SetDeviceModel(deviceModel)
    .SetDeviceName(deviceName)
    .SetDeviceOS(deviceOS)
    .SetDeviceType(deviceType)
    .SetDisplayName(displayName)
    .SetOperatingSystem(operatingSystem)
    .SetSegments(segments)
    .Send((response) => {
        string authToken = response.AuthToken;
        string displayName = response.DisplayName;
        bool? newPlayer = response.NewPlayer;
        GSData scriptData = response.ScriptData;
        var switchSummary = response.SwitchSummary;
        string userId = response.UserId;
    });
