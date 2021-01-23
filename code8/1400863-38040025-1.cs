    public class EnhancedListView : Control, INotifyPropertyChanged
    {
        public EnhancedListView()
        {
            DefaultStyleKey = typeof(EnhancedListView);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set
            {
                var boundItems = new List<EnhancedListViewDataItem>();
                foreach (var obj in (List<string>)value)
                {
                    boundItems.Add(new EnhancedListViewDataItem(this)
                    {
                        DataContext = obj
                    });
                }
                SetValue(ItemsSourceProperty, boundItems);
            }
        }
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(object), typeof(EnhancedListView), new PropertyMetadata(null));
        public bool IsCheckModeEnabled
        {
            get { return (bool)GetValue(IsCheckModeEnabledProperty); }
            set
            {
                SetValue(IsCheckModeEnabledProperty, value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCheckModeEnabled"));
            }
        }
        public static readonly DependencyProperty IsCheckModeEnabledProperty = DependencyProperty.Register("IsCheckModeEnabled", typeof(bool), typeof(EnhancedListView), new PropertyMetadata(null));
    }
    public class EnhancedListViewDataItem : ListViewItem
    {
        public EnhancedListViewDataItem(EnhancedListView listView)
        {
            _listView = listView;
            _listView.PropertyChanged += _listView_PropertyChanged;
            DefaultStyleKey = typeof(EnhancedListViewDataItem);
        }
        private readonly EnhancedListView _listView;
        private void _listView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IsCheckModeEnabled = _listView.IsCheckModeEnabled;
        }
        public bool IsCheckModeEnabled
        {
            get { return (bool)GetValue(IsCheckModeEnabledProperty); }
            set { SetValue(IsCheckModeEnabledProperty, value); }
        }
        public static readonly DependencyProperty IsCheckModeEnabledProperty = DependencyProperty.Register("IsCheckModeEnabled", typeof(bool), typeof(EnhancedListViewDataItem), new PropertyMetadata(null));
    }
