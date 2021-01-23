    public MainWindow(){
       InitializeComponent();
       var vm = new ViewModel(new FindResourceService(list));
       DataContext = vm;
    }
