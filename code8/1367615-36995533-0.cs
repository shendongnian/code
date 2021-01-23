    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();
        }
    }
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Foo item;
        public MyViewModel()
        {
            Item = new Foo();
            Item.Item = "Bar";
        }
       
        public Foo Item
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
                RaisePropertyChanged("Item");
            }
        }
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class Foo
    {
        public string Item { get; set; }
    }
    <TextBox Width="200" Height="30" Text="{Binding Item.Item, Mode=TwoWay}" TextAlignment="Center"/>
