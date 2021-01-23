    public class CustomerVM
    {
        public ObservableCollection<CustomerViewModel> CustomerList { get; set; }
        public CustomerVM()
        {
            CustomerList = new ObservableCollection<CustomerViewModel>();
        }
    }
