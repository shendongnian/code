    public partial class Registration: MetroWindow, INotifyPropertyChanged
    {
        private userlist instance = new userlist();
        private ListCollectionView _list1;
        public ListCollectionView List1
        {
            get { return this._list1; }
            set
        {
            if (this._list1 != value)
            {
                this._list1 = value;
                this.NotifyPropertyChanged("List1");
            }
        }
    }
    public Registration()
    {
        InitializeComponent();
        instance.List.PropertyChanged += ComboPropertyChangedHandler();
    } 
    private void ComboPropertyChangedHandler(object obj)
    {
        List1 = instance.List;
        //or iterate through the list and add as below
        foreach(var item in instance.List)
        {
            List1.Add(item);
        }
    }
    private void confirm_button_click(object sender, RoutedEventArgs e)
        {
             // new user is saved to database
             // * here is where I don't know what to do, how to update the ItemSource
        }
    }
