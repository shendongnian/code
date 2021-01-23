    public interface IEntity
    {
        string Id { get; set; }
    
        IDictionary<string, object> ToDictionary();
        void PopulateFrom(IDictionary<string, object> prop);
    
    }
