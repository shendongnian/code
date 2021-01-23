    byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
    using (var stream = new MemoryStream(jsonBytes))
    {
        output = Deserialize<List<T>>(stream);
    }
     public TResult Deserialize<TResult>(Stream responseStream)
        {
            using (var sr = new StreamReader(responseStream))
            {
                using (var reader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer
                    {
                        MissingMemberHandling =
                            EnforceMissingMemberHandling ? MissingMemberHandling.Error : MissingMemberHandling.Ignore,
                        NullValueHandling = IgnoreNullValues ? NullValueHandling.Ignore : NullValueHandling.Include
                    };
                    return serializer.Deserialize<TResult>(reader);
                }
            }
        }
