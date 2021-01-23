    public class ProductosController : BasicController
    {
        private readonly ProductosService ProductosService;
    
        public ProductosController()
            : this(new ProductosService())
        {
            
        }
    
        public ProductosController(ProductosService productosService)
        {
            ProductosService = productosService;
        }
    }
