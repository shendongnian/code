    public class Transaction
    {
        
    
    public Transaction()
    {
     this.Vehicle = new Vehicle ();
    
    }
    
    [Key]
        public int ID { get; set; }
        ...
    
        public Vehicle Vehicle { get; set; }
    
        ...
    }
