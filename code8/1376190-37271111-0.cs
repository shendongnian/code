    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            Vm = new LoginPageViewModel();
            DataContext = Vm;
        }
        public LoginPageViewModel Vm { get; set; }
    }
