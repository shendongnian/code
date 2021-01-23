    List<Product> products = new List<Product>();
    
    var allProductsWithSubs = (from p in products.SelectMany(x => x.SubProducts).Concat(products)
                                group p by p.ProductID into grp
                                select new
                                {
                                    ProductID = grp.Key,
                                    Quantity = grp.Sum(x => x.Quantity)
                                }).ToList();
    
    public class Product
    {
        public int ProductID { set; get; }
        public double Quantity { set; get; }
        public List<Product> SubProducts { set; get; }
    }
