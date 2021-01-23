    DateTime actualExpiryTime = DateTime.UtcNow.AddHours(1);
    Dictionary<string, string> nameValuePairs = new Dictionary<string, string>();
    // other template property values
    nameValuePairs.Add("apnsexpirytime", actualExpiryTime.ToString("o"));
    await client.SendTemplateNotificationAsync(nameValuePairs);
