    public interface IDatedEntity
    {
        DateTimeOffset Created { get; set; }
        DateTimeOffset Updated { get; set; }
    }
