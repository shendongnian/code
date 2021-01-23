    public class CustomerViewModel : ViewModelBase{
    
        public CustomerViewModel(Customer c){
    _customer = c;
    }
    
    private readonly Customer _customer;
    
    public Customer Customer{
     get{return _customer;}
     set{_customer.Name = value;
       RaisePropertChanged("Customer");
     }
     }
    }
    public Customer:INotifyPropertyChanged
    {
        #INotifyPropetyChanged implementation
        private string _customerName;
        public string CustomerName{
         get{return _customerName;}
         set{_customerName = value;
           RaisePropertChanged("CustomerName");
         }
    }
