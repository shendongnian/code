    static void NotificationSent(object sender, INotification notification)
    {
      var gcmNotification = notification as GcmNotification;
      if (gcmNotification != null) {
        var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic> (gcmNotification.JsonData);
        var notificationId = json.NotificationID;
      }
    }
