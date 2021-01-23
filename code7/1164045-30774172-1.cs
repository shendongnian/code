    public ObjectResult<Article> GetArticleApiKey(string apiKey)
    {
     var apikeyParameter = new ObjectParameter(ApiKeyParameter, apiKey); // Make sure to validate this, because of sql injection
     ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Article>("GetArticleApiKey", apikeyParameter);
    }
