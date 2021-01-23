    public ObjectResult<Article> GetArticleApiKey(string apiKey)
    {
     var apikeyParameter = new ObjectParameter(ApiKeyParameter, apiKey);
     ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Article>("GetArticleApiKey", apikeyParameter);
    }
