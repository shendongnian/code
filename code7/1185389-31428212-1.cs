        public MainWindow()
        {
            InitializeComponent();
            Users = new ObservableCollection<UserViewModel>();
            //setup your data here
            //example:
            UserViewModel userViewModel = new UserViewModel();
            //populate your combobox here
            userViewModel.RuleType.Add("rule1")
            userViewModel.RuleType.Add("rule2");
            userViewModel.RuleType.Add("rule3");
            Users.Add(new UserViewModel());
            
            lbUsers.DataContext = Users ;
        }
