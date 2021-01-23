    public class GridItem 
    {
        public GridItem(String i, String n)
        {
            ID = i;
            Name = n;
        }
        public String ID { get; protected set; }
        public String Name { get; protected set; }
    }
    public partial class MainWindow : Window
    {
        public ObservableCollection<GridItem> GridItems { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            GridItems = new ObservableCollection<GridItem>();
            dataGrid1.ItemsSource = GridItems;
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Window1 win = new Window1(this);
            win.Show();
        }
    }
    public class Window1
    {
        public Window1()
        {
            InitializeComponent();     
        }
        private MainWindow m = null;
        public Window1(Window callingFrom)
        {
            m = callingFrom as MainWindow;
            InitializeComponent();
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //  Because m.GridItems is an ObservableCollection, which has been assigned 
            //  to the datagrid's ItemsSource property, the datagrid will magically 
            //  update itself with the new item. When you add new items, the old items will 
            //  still be seen because you are adding them to the same old collection 
            //  instead of creating a new empty collection every time. 
            m.GridItems.Add(new GridItem(txt2.Text, txt1.Text));
        }
    }
