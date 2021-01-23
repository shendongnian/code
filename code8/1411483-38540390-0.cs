    public abstract class Picture
    {
        public int Id {get;set;}
        public string Type { get; set; }
        public byte[] Content { get; set; }
    }
    public class ProductImage:Picture
    {
        public int ProductId {get;set;}
        public virtual Product Product {get;set;}
    }
    public class CustomerImage:Picture
    {
       public int CustomerId {get;set;}
       public virtual Customer Customer{get;set;}
    }
