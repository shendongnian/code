    public class ProductService : IProductService {
        readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public string GetProductName(int productId) {
            var item = _unitOfWork.productRepository.GetByID(productId);
            if (item != null) {
                return item.ProductName;
            }
            throw new ArgumentException("Invalid product id");
        }
    }
