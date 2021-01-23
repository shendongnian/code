    [HttpGet]
    [Route("lang/{lang}")]
    public HttpResponseMessage GetTranslation(TranslateLang lang)
    {
        var translations = new Translate().GetLibrary()
            .Where(t => t.LangsTranslations.Any(l => l.Language == lang))
            .ToDictionary(
                l => l.Key, 
                l => l.LangsTranslations.First(x => x.Language == lang).Text
            );
        var formatter = new JsonMediaTypeFormatter();
        var json = formatter.SerializerSettings;
        json.ContractResolver = new UpperCaseContractResolver();
        return Request.CreateResponse(HttpStatusCode.OK, translations, formatter);
    }
