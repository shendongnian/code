    JsonSerializerSettings settings = new JsonSerializerSettings
    {
        Converters = new List<JsonConverter>
        {
            new CustomDictionaryConverter<IRequest, IQuoteTimeSeries>("Request", "Data"),
            new CustomDictionaryConverter<DateTime, IQuote>("TimeStamp", "Quote")
        },
        Formatting = Formatting.Indented
    };
    string json = JsonConvert.SerializeObject(repo, settings);
