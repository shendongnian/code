    public class MyItemViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<MyItemModel> _myItems;
        private string _createdBy;
        private string _homepage;
        public ObservableCollection<MyItemModel> MyItems
        {
            get { return _myItems; }
            set
            {
                _myItems = value;
                OnPropertyChanged("MyItems");
            }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set
            {
                _createdBy = value;
                OnPropertyChanged("CreatedBy");
            }
        }
        public string Homepage
        {
            get { return _homepage; }
            set
            {
                _homepage = value;
                OnPropertyChanged("Homepage");
            }
        }
        
        //-----------------------------------------------------------------------
        public MyItemViewModel()
        {
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var mitem = await MovieDataSource.GetItemAsync((String)e.NavigationParameter);
            // You must have data inside mitem if you put a breakpint at the below line
            MyItems = mitem;
        }
        //-----------------------------------------------------------------------
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
