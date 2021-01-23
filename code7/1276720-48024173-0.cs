    var tempDataDictionaryFactory = context.RequestServices.GetRequiredService<ITempDataDictionaryFactory>();
    var tempDataDictionary = tempDataDictionaryFactory.GetTempData(context);
    if (tempDataDictionary.TryGetValue(MyClaims.Claim1, out object value))
    {
        return (string)value;
    }
