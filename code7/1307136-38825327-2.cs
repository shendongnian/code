    public partial class MainWindow : Window
    {
        ViewModel _vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MvvmBased_OnClick(object sender, RoutedEventArgs e)
        {
            var scrollViewer = list.GetChildOfType<ScrollViewer>();
            if (DataContext != null)
            {
                _vm.VerticalOffset = scrollViewer.VerticalOffset;
                _vm.HorizontalOffset = scrollViewer.HorizontalOffset;
                DataContext = null;
            }
            else
            {
                scrollViewer.ScrollToVerticalOffset(_vm.VerticalOffset);
                scrollViewer.ScrollToHorizontalOffset(_vm.HorizontalOffset);
                DataContext = _vm;
            }
        }
        private void ViewBased_OnClick(object sender, RoutedEventArgs e)
        {
            var scrollViewer = list.GetChildOfType<ScrollViewer>();
            if (DataContext != null)
            {
                View.State[typeof(MainWindow)] = new Dictionary<string, object>()
                {
                    { "ScrollViewer_VerticalOffset", scrollViewer.VerticalOffset },
                    { "ScrollViewer_HorizontalOffset", scrollViewer.HorizontalOffset },
                    // Additional fields here
                };
                DataContext = null;
            }
            else
            {
                var persisted = View.State[typeof(MainWindow)];
                if (persisted != null)
                {
                    scrollViewer.ScrollToVerticalOffset((double)persisted["ScrollViewer_VerticalOffset"]);
                    scrollViewer.ScrollToHorizontalOffset((double)persisted["ScrollViewer_HorizontalOffset"]);
                    // Additional fields here
                }
                DataContext = _vm;
            }
        }
    }
