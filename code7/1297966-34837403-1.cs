    public partial class Colors
        {
            public Colors()
            {
                this.Products = new HashSet<Products>();
            }
    
            public int ColorID { get; set; }
            public string Hex { get; set; }
            public string ColorName { get; set; }
    
            public virtual ICollection<Products> Products { get; set; }
        }
    
    public static class EntityExtensions
    {
        public static int GetProductCount(this Colors colors)
        {
            return colors.Products.Count();
        }
    }
