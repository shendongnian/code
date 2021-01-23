    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;}
    }
    
    public ActionResult List()
    {
        List<Product> products = Database.GetProducts();
        return View(products);
    }
    
    public ActionResult Details(string id)
    {
        Product product = Database.GetProducts().Where(p => p.Id == id).Single();
        return View(Product);
    }
