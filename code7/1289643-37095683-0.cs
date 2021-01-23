    public interface IAuditableEntity 
    {
        int? CreatedById { get; set; }
        DateTime Created { get; set; }
        int? ModifiedById { get; set; }
        DateTime Modified { get; set; }
    }
