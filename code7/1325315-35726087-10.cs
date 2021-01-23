    public class CustomerListViewModel
    {
        private readonly ICustomerListModel customerListModel;
        public CusomterListViewModel(ICustomerListModel customerListModel)
        {
            this.customerListModel = customerListModel;
        }
        public ObservableCollection<ICustomer> Customers
        {
            get
            {
                return this.customerListModel.Customers;
            }
        }
    }
