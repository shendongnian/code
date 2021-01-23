    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
            MyObject myObject = new MyObject { MyPath = "value" };
            BindingOperations.SetBinding(ResultText, TextBlock.TextProperty, new Binding("MyPath")
            {
            Source = myObject,
            StringFormat = "MyFormat"
            });
            BindingOperations.SetBinding(ResultToolTip, TextBlock.TextProperty, new Binding("MyPath")
            {
            Source = myObject,
            StringFormat = "MyFormat"
            });
        }
         
    }
    class MyObject
    {
        private string _myPath;
        public string MyPath
        {
            get { return _myPath; }
            set { _myPath = value; }
        }
    }
