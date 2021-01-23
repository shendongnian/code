    public interface IMeasurementProtocolApi
    {
        [Post("/collect")]
        Task Collect([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
    }
    
    var data = new Dictionary<string, object> {
        {"v", 1}, 
        {"tid", "UA-1234-5"}, 
        {"cid", new Guid("d1e9ea6b-2e8b-4699-93e0-0bcbd26c206c")}, 
        {"t", "event"},
    };
    
    // Serialized as: v=1&tid=UA-1234-5&cid=d1e9ea6b-2e8b-4699-93e0-0bcbd26c206c&t=event
    await api.Collect(data);
