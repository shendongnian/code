    public abstract class BaseModel : IAuditable
    {
        string IAuditable.CreatedBy { get; set; }
    
        DateTime? IAuditable.CreatedDate { get; set; }
    }
