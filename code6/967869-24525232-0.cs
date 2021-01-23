    public class Products
    {
        public string Name { get; set; }
    }
        
    
    static void Main()
    {
        IQueryable<Products> qry = new List<Products> {         
            new Products() {Name = "Football" },
            new Products() {Name = "Baseball" },
            new Products() {Name = "Glove" },
        }.AsQueryable();
            
        var r = ApplyFilter(qry, p => p.Name.Contains("ball"));
    }
               
    
    private static IQueryable<Products> ApplyFilter(IQueryable<Products> qry, Expression<Func<Products, bool>> predicate)
    {
        return qry.Where(predicate);
    }
