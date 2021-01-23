    public class User : IDatedEntity
    {
        // ...
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
