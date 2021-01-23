    public class Visit
    {
     public int VisitId { get; set; }
     public DateTime Start { get; set; }
           
     public int CustomerId { get; set; }
     public virtual Customer Customer { get; set; }
    }
    
    public class Customer
    {
     public int CustomerId{ get; set; }
    }
