    public class ProductViewModel {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Whatever { get; set; }
    }
    public class GetProductById : IQuery<ProductViewModel>
    {
    	public int Id { get; private set; }
    	
    	public GetProductById(int id)
    	{
    		Id = id;
    	}
    }
    
    public class HandleGetProductById : IHandleQuery<GetProductById, ProductViewModel>
    {
    	private readonly IRepository<Product> _productRepository;
        	
    	public HandleGetProductById(IRepository<Product> productRepository) 
    	{
    		_productRepository = productRepository;
    	}
    	
    	public ProductViewModel Handle(GetProductById query)
    	{
    		var product = _productRepository.Get(query.Id);
    		return product.Select(x => new ProductViewModel {
    			Name = x.Name,
    			Price = x.Price;
    		});
    	}
    }
