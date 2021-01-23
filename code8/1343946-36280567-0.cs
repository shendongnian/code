    public struct MyStruct
    {
        public String ViewType;
        public object objCB;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<MyStruct> mylist = new List<MyStruct>(); //Global list
       MyStruct mystr; //Global struct object
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            mystr = new MyStruct();
            mystr.objCB = sender; //filling object value in struct object
        }
        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            mylist.Add(mystr);
        }
    }
