    public sealed partial class MainPage : Page
    {
        private int _selectedIndex = 0;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _selectedIndex = MyPivot.SelectedIndex;
            MyPivot.SelectionChanged += OnSelectionChanged;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_selectedIndex == 0 && MyPivot.SelectedIndex == MyPivot.Items.Count-1)
            {
                ChangeSelectedIndex(_selectedIndex);
                return;
            }
            if(_selectedIndex == MyPivot.Items.Count-1 && MyPivot.SelectedIndex == 0)
            {
                ChangeSelectedIndex(_selectedIndex);
                return;
            }
            _selectedIndex = MyPivot.SelectedIndex;
        }
        private void ChangeSelectedIndex(int index)
        {
            Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                MyPivot.SelectedIndex = index;
            });
        }
    }
