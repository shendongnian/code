     public MainWindow()
    {
        InitializeComponent();
        vm = new ViewModel();
        //ct = new CompletionTime();
        //ct.TestsOrdered = 8000;
        vm.Name = "John Doe";
        vm.TestsCompleted = 0;
        vm.TestsOrdered = 0;
        vm.TestsRemaining = 0;
        //this.MyContext.DataContext = vm;
        this.DataContext = vm; // <-- Like so
    }
