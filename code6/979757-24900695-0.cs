    public class ProductDto {
        public ProductDto() { }
        public ProductDto(Product product) 
        {
    		AddProduct(product)
    	}
    	public AddProduct(Product product)
    	{
    		Name = product.name
    	}
    }
