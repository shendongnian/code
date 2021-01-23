    public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken) {
      ParseInstallation installation = ParseInstallation.CurrentInstallation;
      installation.SetDeviceTokenFromData(deviceToken);
      installation.SaveAsync();
    }
