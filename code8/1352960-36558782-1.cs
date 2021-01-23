    public partial class UsersWindow : Window
    {
        public UsersWindow(UsersViewModel uvm)
        {
            InitializeComponent();
            var vm = new UsersViewModel();
            //  initialize vm if needed
            DataContext = vm;
        }
    }
