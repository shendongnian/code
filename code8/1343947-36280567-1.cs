    public class MyStruct
    {
        public String ViewType;
        public object objCB;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<MyStruct> _mylist = new List<MyStruct>(); //Global list
        MyStruct _mystr = new MyStruct(); //Global struct object
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonBase1_OnClick(object sender, RoutedEventArgs e)
        {
            _mystr.objCB = sender; //filling object value in struct object
        }
        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            _mylist.Add(_mystr);
        }
    }
