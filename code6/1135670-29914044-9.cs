    public class Product { public string Title { get; set; } }
    public class ProductModel { public string Title { get; set; } }
    
    static void Main(string[] args)
    {
        Product lc = new Product();
        ProductModel rc = new ProductModel();
        rc.Title = "abc";
        bool modified = SetIfModified(l => l.Title, r => r.Title, lc, rc);
        // modified is true
        // lc.Title is "abc"
    }
