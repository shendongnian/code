    public class ProductTypeService
	{
		private readonly IUnitOfWork _unitOfWork;
		public ProductTypeService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void AddProductType(ProductType productType)
		{
			_unitOfWork.ProductTypes.Add(productType);
		}
	}
