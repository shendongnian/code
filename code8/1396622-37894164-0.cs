    HttpContent requestContent = new ObjectContent(typeof(SendMessage<object>), newMessage,
    new JsonMediaTypeFormatter
    {
        SerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CustomPropertyNamesContractResolver
            {
                Case = IdentifierCase.UnderscoreSeparator
            },
            NullValueHandling = NullValueHandling.Ignore
        },
    SupportedEncodings = {Encoding.UTF8}
    });
