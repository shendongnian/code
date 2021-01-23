    public TDest SerializeCopy<TDest>(object srcVal)
        where TDest : class, new()
    {
        if (srcVal == null) { return null; }
        var temp = JsonConvert.SerializeObject(srcVal);
        return JsonConvert.DeserializeObject<TDest>(temp);
    }
