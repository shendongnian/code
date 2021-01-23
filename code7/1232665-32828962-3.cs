    public T Get<T>()
    {
        string json = ...; // get data somehow
        return JsonConvert.DeserializeObject<T>(json);
    }
