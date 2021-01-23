    public class ProductModel
    {
       public virtual CategoryModel Category { get; set; }
    }
    public class CategoryModel 
    {
       public virtual UserAddress Address {get; set;}
    }
    public class UserAddress
    {
       public string Street1 {get; set;}
    }
