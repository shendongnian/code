    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static List<MyProduct> FakeList
        {
            get
            {
                return new List<MyProduct>
                {
                    new MyProduct { Price = 5 },
                    new MyProduct { Price = 10 },
                    new MyProduct { Price = 20 }
                };
            }
        }
    }
