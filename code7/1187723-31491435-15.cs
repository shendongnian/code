    public class ExampleViewModel : ViewModelBase 
    {
        public ExampleViewModel(Example2ViewModel example2ViewModel)
        {
        }
    }
    public class Example2ViewModel : ViewModelBase 
    {
        public Example2ViewModel(ICustomerRepository customerRepository)
        {
        }
    }
    public class MainWindowViewModel : ViewModelBase 
    {
        public MainWindowViewModel(ExampleViewModel example2ViewModel)
        {
        }
    }
    // Unity Bootstrapper Configuration 
    container.RegisterType<ICustomerRepository, SqlCustomerRepository>();
    // You don't need to register Example2ViewModel and ExampleViewModel unless 
    // you want change their container lifetime manager or use InjectionFactory
    
