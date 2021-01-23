    public static class MenuExtension
    {
        public static List<MenuFlyoutItem> GetMyItems(DependencyObject obj)
        { return (List<MenuFlyoutItem>)obj.GetValue(MyItemsProperty); }
        public static void SetMyItems(DependencyObject obj, List<MenuFlyoutItem> value)
        { obj.SetValue(MyItemsProperty, value); }
        public static readonly DependencyProperty MyItemsProperty =
            DependencyProperty.Register("MyItems", typeof(List<MenuFlyoutItem>), typeof(MenuExtension),
            new PropertyMetadata(new List<MenuFlyoutItem>(), (sender, e) =>
            {
                Debug.WriteLine("Filling collection");
                var menu = sender as MenuFlyoutSubItem;
                menu.Items.Clear();
                foreach (var item in e.NewValue as List<MenuFlyoutItem>) menu.Items.Add(item);
            }));
    }
    public sealed partial class MainPage : Page,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        public List<MenuFlyoutItem> Options { get; set; } = new List<MenuFlyoutItem>
        {
            new MenuFlyoutItem {Text="Start item" },
            new MenuFlyoutItem {Text="Start item" },
            new MenuFlyoutItem {Text="Start item" }
        };
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Options = new List<MenuFlyoutItem> { new MenuFlyoutItem { Text = "Modified" } };
            RaiseProperty(nameof(Options));
    //      mysub.Items.Add(new MenuFlyoutItem { Text = "modified" }); // even this cannot be done
        }
    } 
