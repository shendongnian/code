    public class Bag :IEntity
    {
        ...
        public virtual IList<ProductsOfBag> Products { get; set; }     
    }
