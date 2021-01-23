    public class Item
    {
       public Guid Id { get; set; }
       public Service Service { get; set; }
    }
    
    public class Service
    {       
        public int Id { get; set; }    
        public string ServiceCode { get; set; }
        
        public Item Item { get; set; } //for One to One relationship
        // or
        public virtual ICollection<Item> Items { get; set; } // for One service to Many Items relationship
    }
