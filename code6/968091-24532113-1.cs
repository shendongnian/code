        // this are my constructors
        // obj is your vm
        public DetailV(object obj)
        {
            InitializeComponent();
            DataContext = obj;
            CPresenter.Content = obj;
            initializeCostumComponent();
        }
        // dataContext is your vm and 
        // content is an Usercontrol
        public DetailV(object dataContext, object content)
        {
            InitializeComponent();
            DataContext = dataContext;
            CPresenter.Content = content;
            initializeCostumComponent();
        }
