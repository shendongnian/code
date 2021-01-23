    public class Product : IEntity
    {
        ...    
        public virtual IList<ProductsOfBag> Bags { get; set; }
    }
