    interface IIdentifiable
    {
        string Id { get; }
    }
    class GenericRepository <T> : ... where T : IIdentifiable
    {
        // ...
    }
