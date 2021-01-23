    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            MenuList.Add(new MenuItem()
            {
                Header = "MenuItem1",
                Command = MenuItemCommand,
                CommandParameter = "FirstMenu"
            });
            MenuList.Add(new MenuItem()
            {
                Header = "MenuItem2",
                Command = MenuItemCommand,
                CommandParameter = "SecondMenu"
            });
        }
        private ObservableCollection<MenuItem> _menuList;
        public ObservableCollection<MenuItem> MenuList
        {
            get { return _menuList ?? (_menuList = new ObservableCollection<MenuItem>()); }
            set { _menuList = value; RaisePropertyChanged("MenuList"); }
        }
        private RelayCommand<string> _MenuItemCommand;
        public RelayCommand<string> MenuItemCommand
        {
            get { return _MenuItemCommand ?? (_MenuItemCommand = new RelayCommand<string>(cmd)); }
            set { _MenuItemCommand = value; }
        }
        private void cmd(string value)
        {
            MessageBox.Show(value);
        }
    }
