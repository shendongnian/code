    public class A
    {
        //Property
        //must be set somewhere (e.g. constructor)
        public List<Product> Products { get; private set; }
        //Method
        public List<Product> GetProducts()
        {
            //return list of products
        }
    }
    public class B
    {
        public void Display()
        {
            var a = new A(); 
            foreach (var product in a.Products /*OR a.GetProducts()*/)
            {
                Console.WriteLine(product);
            }
        }
    }
