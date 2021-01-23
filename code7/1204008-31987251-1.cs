    class Program
    {
        static void Main(string[] args)
        {
            // create a list of products
            List<Product> products = new List<Product>();
            // append, modify, delete list entries
            products.Add(new Product("asdas", 0.2));
            // serialize them and output text to console
            Console.WriteLine(fastJSON.JSON.Instance.ToJSON(products));
        }
    }
