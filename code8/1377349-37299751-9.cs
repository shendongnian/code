    public partial class MainWindow : Window
    {
        //MainWindow.xaml.cs
        public MainWindow()
        {
            InitializeComponent();
            //Create a new Instance of your ViewModel
            MyViewModelClass viewModel = new MyViewModelClass();
            //Set the DataContext (BindingContext (i.e. where to look for the Bindings) to your ViewModel
            DataContext = viewModel;
        }
    } 
