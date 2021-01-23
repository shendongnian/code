    public partial class IntelliSenseUserControl : UserControl, INotifyPropertyChanged
    {
        public IntelliSenseUserControl()
        {
            InitializeComponent();
            DependencyPropertyDescriptor prop = DependencyPropertyDescriptor.FromProperty(ItemsSourceProperty, typeof(IntelliSenseUserControl));
            prop.AddValueChanged(this, ItemsSourceChanged);
        }
        private void ItemsSourceChanged(object sender, EventArgs e)
        {
            FilteredItemsSource = new ListCollectionView((IList)ItemsSource);
            FilteredItemsSource.Filter = (arg) => { return arg == null || string.IsNullOrEmpty(textBox.Text) || arg.ToString().Contains(textBox.Text.Trim()); };
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(IntelliSenseUserControl), new FrameworkPropertyMetadata(null) { BindsTwoWayByDefault = true });
        public object ItemsSource
        {
            get { return (object)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(object), typeof(IntelliSenseUserControl), new PropertyMetadata(null));
        #region Notified Property - FilteredItemsSource (ListCollectionView)
        public ListCollectionView FilteredItemsSource
        {
            get { return filteredItemsSource; }
            set { filteredItemsSource = value; RaisePropertyChanged("FilteredItemsSource"); }
        }
        private ListCollectionView filteredItemsSource;
        #endregion
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                popup.IsOpen = false;
            }
            else
            {
                popup.IsOpen = true;
                FilteredItemsSource.Refresh();
            }
        }
        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }
        private void ListView_Selected(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Text = listView.SelectedItem.ToString().Trim();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
