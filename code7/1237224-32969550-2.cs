    //your data 
    public ObservableCollection<Customer> MySource {get;set;}
    //Command to add a new row
    public ICommand AddNewCustomerCommand {get{return _lazyAddCommand.Value;}}
    private readonly Lazy<DelegateCommand> _lazyAddCommand;
    //ctor
    public MyViewmodel()
    {
       MySource = new ObservableCollection<Customer>();
       _lazyAddCommand= new Lazy<DelegateCommand>(() => new DelegateCommand(AddNewCustomerCommandExecute, CanAddNewCustomerCommandExecute));
     }
     private bool CanAddNewCustomerCommandExecute()
     {
         return true;//your Conditions goes here
     }
     private void AddNewCustomerCommandExecute()
     {
         if (!CanAddNewCustomerCommandExecute())
                return;
          //Add new Customer
          MySource.Add(new Customer());
      }
