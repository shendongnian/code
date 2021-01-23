    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		var service = new ProductService();
    		service.Create(new Product());
    		service.Create(new Supplier());
    		service.Create(new {name="test"});
    	}
    }
    
    
    public class ProductService
    {
        public void Create(Product obj)
        {
            Product();
        }
    	public void Create(Supplier obj)
    	{
    		Supplier();
    	}
        public void Create(Object obj)
        {
            Console.WriteLine("Unknown type called" + obj.GetType().Name);
        }
    
        private void Supplier()
        {
            Console.WriteLine("Supplier called");
        }
        private void Product()
        {
            Console.WriteLine("Product called");
        }
    }
    public class Product {}
    public class Supplier {}
