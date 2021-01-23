    public sealed partial class MainPage : Page
    {
        public ObservableCollection<String> Collection = new ObservableCollection<string>();
        private bool incall;
        private int offset;
        int _noofelements;
        ScrollViewer _scrollViewer;
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            listview.ItemsSource = Collection;
            addNumber(0);
        }
        public static ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer) return depObj as ScrollViewer;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = GetScrollViewer(child);
                if (result != null) return result;
            }
            return null;
        }
        private void OnViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            ScrollViewer view = (ScrollViewer)sender;
            if ((view.VerticalOffset > 0.9 * view.ScrollableHeight) & !incall)
            {
                incall = true;
                addNumber(++offset);
            }
        }
        private void addNumber(int offset)
        {
            int start = offset * 20;
            for (int i = start; i < start + 20; i++)
            {
                if (i % 20 == 0)
                    Collection.Insert(0, (_noofelements++).ToString());
                else
                    Collection.Add((_noofelements++).ToString());
            }
            incall = false;
        }
        private void listview_Loaded(object sender, RoutedEventArgs e)
        {
            _scrollViewer = GetScrollViewer(listview);
            if (_scrollViewer != null)
            {
                _scrollViewer.ViewChanged += OnViewChanged;
            }
        }
