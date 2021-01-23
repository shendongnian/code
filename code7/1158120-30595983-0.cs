    //xaml
    <ListBox x:Name="ListBox" DisplayMemberPath="MyStringProperty"/>
    //code behind
     public partial class MainWindow : Window
     {
        public MainWindow()
        {
            InitializeComponent();
            this.LoadItems();
        }
        private void LoadItems()
        {
            ListBox.Items.Add(new MyListItem() { MyBoolProperty = true, MyStringProperty = "Hello" });
            ListBox.Items.Add(new MyListItem() { MyBoolProperty = false, MyStringProperty = "World" });
        }
    }
    //my object class
    public class MyListItem : NotificationObject
    {
        private string _myString;
        private bool _myBool;
        public MyListItem()
        { }
        public string MyStringProperty
        {
            get { return _myString; }
            set
            {
                _myString = value;
                this.RaisePropertyChanged("MyStringProperty");
            }
        }
        public bool MyBoolProperty
        {
            get { return _myBool; }
            set
            {
                _myBool = value;
                this.RaisePropertyChanged("MyBoolProperty");
            }
        }
    }
