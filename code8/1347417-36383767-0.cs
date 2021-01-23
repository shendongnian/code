    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
    string json1 = JsonConvert.SerializeObject(dt, Formatting.Indented, settings);
    string json2 = JsonConvert.SerializeObject(cls, Formatting.Indented, settings);
