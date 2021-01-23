        public partial class Networking : Window
        {
            public NetworkViewModel MyViewModel { get; set; }
            public Networking()
            {
                InitializeComponent();
                MyViewModel = new NetworkViewModel();
                this.DataContext = MyViewModel;
            }
        }
