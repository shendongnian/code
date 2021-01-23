    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
    
    
            public MainWindow()
            {
    
                InitializeComponent();
                obj.Show(); //and must be inside of a method, function or constructor.
    
            }
    
            myClass obj = new myClass();
            //obj.Show(); //not possible beacause is not a public method.!!
    
    
        }
    
        public partial class myClass
        {
            //public method.
            public void Show()
            {
    
            }
        }
    
    }
