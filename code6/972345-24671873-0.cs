     public MainView()
        {
            InitializeComponent();
            var vm = DataContext as MainViewModel;
            vm.PropertyChanged += vm_PropertyChanged;
        }
        void vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "MyProperty")
            {
                //Do something
            }
        }
