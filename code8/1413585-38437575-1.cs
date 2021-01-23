    class Program
        {
            static List<CartLine> linecollection = new List<CartLine>();
    
            static void Main(string[] args)
            {
                ProductClass product = new ProductClass() { ProductID = 0 };
    
                linecollection.Add(new CartLine() { Product = product, Quantity = 80 });
                linecollection.Add(new CartLine() { Product = new ProductClass() { ProductID = 1 }, Quantity = 60 });
                linecollection.Add(new CartLine() { Product = new ProductClass() { ProductID = 2 }, Quantity = 40 });
    
                CartLine line = linecollection.Where(P => P.Product.ProductID == product.ProductID).FirstOrDefault();
                if (line == null)
                    linecollection.Add(new CartLine() { Quantity = 100 });
                else
                    line.Quantity = 100;
            }
        }
    
        class CartLine
        {
            public ProductClass Product
            {
                get; set;
            }
            public int Quantity
            {
                get; set;
            }
        }
    
        class ProductClass
        {
            public int ProductID
            {
                get; set;
            }
        }
