    public class YourClass
    {
        public YourClass()
        {
            TaskEx.Run(() =>
            {
                var listCustomer = RemplireListCustomer();
                CustomerList = new ObservableCollection<CustumerModel>(listCustomer);
            });
        }
        public ObservableCollection<CustumerModel> CustomerList { get; private set; }
    }
    
