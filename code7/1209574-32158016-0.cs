    public class ProductService
    {
        public void Create<T>(T obj)
        {
            if (typeof(Supplier) == typeof(T))
                Supplier(obj); //Call Supplier Method;
            else if (typeof(Product) == typeof(Product))
                Product(); //Call Product Method;
            else
                throw new ArgumentOutOfRangeException("Unrecognized type", "type");
        }
    
        private void Supplier<T>(T s)
        {
            //statements
            Console.WriteLine("Supplier");
        }
        private void Product()
        {
            //statements
            Console.WriteLine("Product");
        }
    }
