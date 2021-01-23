    JsonSerializerSettings jss = new JsonSerializerSettings();
    jss.ConfigureForNodaTime(DateTimeZoneProviders.Bcl);
    
    jss.Converters.Remove(NodaConverters.LocalTimeConverter);
    JsonConverter newTimeConverter = new NodaPatternConverter<LocalTime>(LocalTimePattern.CreateWithInvariantCulture("HH:mm"));
    jss.Converters.Add(newTimeConverter);
	
	MyObject mo2 = JsonConvert.DeserializeObject<List<MyObject>>(serializedObject2, jss)[0];
