    public class Mycontext:DbContext
    {
        public IDbSet<Product> Products { get; set; }
        // other sets 
    }
