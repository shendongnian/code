    interface IIdentifiable
    {
        public string Id { get; }
    }
    class GenericRepository <T> : ... where T : IIdentifiable
    {
        // ...
    }
