    public class ViewModel
    {
        private readonly IClientModel _clientModel;
        private readonly IProductModel _productModel;
        public ViewModel(IClientModel clientModel, IProductModel productModel)
        {
            _clientModel = clientModel;
            _productModel = productModel;
        }
        // Logic of your view model
    }
