    /// <summary>
    /// TabControl withCustom TabItem
    /// </summary>
    public class MyTabControl : TabControl
    {
        /// <summary>
        /// TabItem override
        /// </summary>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyTabItem();
        }
    }
    public class MyTabItem : TabItem
    {
        /// <summary>
        /// Delete Command 
        /// </summary>
        public static DependencyProperty DeleteCommandProperty = DependencyProperty.Register(
           "DeleteCommand", typeof(ICommand), typeof(MyTabItem));
        /// <summary>
        /// Delete
        /// </summary>
        public ICommand DeleteCommand
        {
            get { return (ICommand)GetValue(DeleteCommandProperty); }
            set { SetValue(DeleteCommandProperty, value); }
        }
    }
    
    public class MyCommand : ICommand
    {
        public void Execute(object parameter)
        {
            MessageBox.Show("Hello WPF", "Message");
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged { add { } remove { } }
    }
    public class MyContext
    {
        public ICommand MyDeleteCommand { get; set; }
        public List<object> MyTabItemList { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = new List<object>();
            list.Add(new TextBlock() { Text = "Test 1" });
            list.Add(new MyTabItem() { Content = "Test Content 2", Header = "Test Header 2" });
            list.Add(new TabItem() { Content = "Test Content 3", Header = "Test Header 3" });
            this.DataContext = new MyContext()
            {
                MyTabItemList = list,
                MyDeleteCommand = new MyCommand()
            };
        }
    }
