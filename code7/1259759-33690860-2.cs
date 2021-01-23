    public sealed partial class MainPage : Page
    {
        public MyViewModel ViewModel
        {
            get
            {
                return (MyViewModel)this.DataContext;
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
