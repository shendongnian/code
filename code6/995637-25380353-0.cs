    public class SomeView
    {
        public SomeView(SomeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
