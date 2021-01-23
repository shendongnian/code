    {
        // ...
        public void TestInheritance()
        {
            try
            {
                Product p01 = new Product() { ProductBarcode = "p01" };
                ProductPlus pp01 = new ProductPlus() { ProductBarcode = "pp01" };
                Product p02 = (ProductPlus)pp01;
                //ProductPlus pp02 = (ProductPlus)p01; // throws a cast error
    
                List<Product> productList = new List<Product>();
                productList.Add(p01);
                productList.Add(pp01);
    
                //List<ProductPlus> productPlusList = productList.ConvertAll(x => (ProductPlus)x).ToList(); // throws a cast error 
    
                List<ProductPlus> productPlusList = productList.Where(x => x is ProductPlus).ToList().ConvertAll(x => (ProductPlus)x).ToList();
                foreach (ProductPlus p in productPlusList)   
                    Debug.WriteLine(p.ProductBarcode);  // 1 item 
    
                List<ProductPlus> productPlusMajicList = productList.Select(x => new ProductPlus(x)).ToList();
                foreach (ProductPlus p in productPlusMajicList)
                    Debug.WriteLine(p.ProductBarcode);   // majic 2 tiems
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
    
    
        }
    }
    public partial class Product
    {
        public int? ProductID { get; set; }
        public string  ProductBarcode { get; set; }
        public int? CompanyID { get; set; }
        public Product() { }
        public Product(Product p)
        {
            ProductID = p.ProductID;
            ProductBarcode = p.ProductBarcode;
            CompanyID = p.CompanyID;
        }
    }
    
    public class ProductPlus : Product
    {
        public bool? Restock { get; set; }
        public DateTime? DateSold { get; set; }
        public ProductPlus() { }
        public ProductPlus(Product p) : base(p) { }
    }
