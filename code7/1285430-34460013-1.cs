    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ProductsViewModel = new ProductsVM();
            OrdersViewModel = new CustomerOrdersVM(ProductsViewModel);
        }
        public CustomerOrdersVM OrdersViewModel { get; private set; }
        public ProductsVM ProductsViewModel { get; private set; }
    }
