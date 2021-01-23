        public partial class MainWindow : Window,INotifyPropertyChanged
        {
            private ObservableCollection<ListViewItemObj> _listViewCollection;
            private ListViewItemObj _selectedListViewItem;
    
    
            public ObservableCollection<ListViewItemObj> ListViewCollection
            {
                get { return _listViewCollection; }
                set
                {
                    if (Equals(value, _listViewCollection)) return;
                    _listViewCollection = value;
                    OnPropertyChanged();
                }
            }
    
            public ListViewItemObj SelectedListViewItem
            {
                get { return _selectedListViewItem; }
                set
                {
                    if (Equals(value, _selectedListViewItem)) return;
                    _selectedListViewItem = value;
                    OnPropertyChanged();
                }
            }
    
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
            }
         }
