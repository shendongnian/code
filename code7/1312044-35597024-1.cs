    public class MyStyleSelector : StyleSelector
        {
            public override Style SelectStyle(object item, DependencyObject container)
            {
                var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
                if (item is MyObject)
                    return (Style)itemsControl.FindResource("DynamicItemStyle");
                else 
                    return (Style)itemsControl.FindResource("StaticItemStyle");
            }
        }
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                MyObject dynamicObject = new MyObject();
                dynamicObject.Title = "dynamic1";
                Windows.Add(dynamicObject);
                Windows.Add(new MyObject() { Title = "dynamic2" });
            }
    
            private ObservableCollection<MyObject> _windows = new ObservableCollection<MyObject>();
    
    
            public ObservableCollection<MyObject> Windows
            {
                get { return _windows; }
                set { _windows = value; }
            }
        }
    
        public class MyObject
        {
            public string Title { get; set; }
        }
`   
