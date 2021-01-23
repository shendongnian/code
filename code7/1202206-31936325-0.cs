    public class ServiceAccount
    {
       public long Id { get; set; }
       public virtual Customer Customer { get; set; }
       [Required]
       public virtual Service Service { get; set; }
    }
