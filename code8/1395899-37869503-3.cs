    public T GetFromApi<T>(string apiRequest, string content) where T : class
    ...
    else
    {
        log.Error("Error accessing API.");
        return null;
    }
