    public class ViewModel1
    {
        private readonly IClientModel _clientModel;
        private readonly IProductModel _productModel;
        public MyViewModel(IClientModel clientModel, IProductModel productModel)
        {
            _clientModel = clientModel;
            _productModel = productModel;
        }
        // Logic of your view model
    }
