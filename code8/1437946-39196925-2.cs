	var client = new ElasticClient();
    var document = new MyDocument
    {
        DateTime = new DateTime(2016, 8, 29, 9, 46, 0),
        NullableDateTime = null,
        DateTimeOffset = new DateTimeOffset(2016, 8, 29, 9, 46, 0, TimeSpan.Zero),
        NullableDateTimeOffset = new DateTimeOffset(2016, 8, 29, 9, 46, 0, TimeSpan.Zero),
    };
    client.Index(document);
