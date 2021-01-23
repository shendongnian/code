    public class CustomerListModel : ICustomerListModel
    {
        private readonly IDatabase database;
        private readonly ObservableCollection<ICustomer> customers;
        public CustomerListModel(IDatabase database)
        {
            this.database = database;
            this.customers = new ObservableCollection(database.GetCustomerList());
        }
        public ObservableCollection<ICustomer> Customers
        {
            get
            {
                return this.customers;
            }
        }
    }
