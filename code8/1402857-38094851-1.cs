    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new ViewModel();
            DataContext = viewModel;
            Loaded += async (s, e) => await viewModel.LoadCustomers();
        }
    }
    public class Customer
    {
        public string Name { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<Customer> Customers { get; private set; }
            = new ObservableCollection<Customer>();
        public async Task LoadCustomers()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 2000; i++)
                {
                    var customer = new Customer
                    {
                        Name = string.Format("Customer {0}", i + 1)
                    };
                    Application.Current.Dispatcher.Invoke(() => Customers.Add(customer));
                }
            });
        }
    }
