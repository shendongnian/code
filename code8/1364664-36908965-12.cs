    public class SaveProduct : ICommand 
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
    	
    	public SaveProduct(string name, double price) 
    	{
    	    Name = name;
    		Price = price;
    	}
    }
    
    public class HandleSaveProduct : IHandleCommand<SaveProduct> 
    {
    	private readonly IRepository<Product> _productRepository;
    	
    	public HandleSaveProduct(IRepository<Product> productRepository) 
    	{
    		_productRepository = productRepository;
    	}
    	
    	public void Handle(SaveProduct command) 
    	{
    		var product = new Product {
    			Name = command.Name,
    			Price = command.Price
    		};
    		
    		_productRepository.Save(product);
    	}
    }
