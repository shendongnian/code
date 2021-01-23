    public partial class ShellView : Window
    {
        public ShellView(ShellViewModel viewModel)
        {
            this.InitializeComponent();
            // Set the ViewModel as this View's data context.
            this.DataContext = viewModel;
        }
