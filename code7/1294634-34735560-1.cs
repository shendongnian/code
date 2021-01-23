    using System.Windows;
    using WpfApplication1.Model;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            private MainWindowViewModel vm { get; } = new MainWindowViewModel();
            public MainWindow()
            {
                InitializeComponent();
                vm.Customers.Add(new Customer("FirstName", "LastName", "Email", "Company"));
                this.DataContext = vm;
            }
        }
    }
