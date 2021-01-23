    public partial class Window4 : MetroWindow
    {
        MyViewModel viewModel;
        public Window4()
        {
            InitializeComponent();
        }
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = new MyViewModel();
            DataContext = viewModel;
            viewModel.MyIcon = "appbar_box";
            viewModel.MyResource = (Visual)Resources[viewModel.MyIcon]; 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.MyIcon == "appbar_box")
                viewModel.MyIcon = "appbar_add";
            else viewModel.MyIcon = "appbar_box";
            viewModel.MyResource = (Visual)Resources[viewModel.MyIcon];
        }
    }
