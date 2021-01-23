    public class MainWindowViewModel
    {
        public event EventHandler CloseRequested;
        private void Close()
        {
            var closeRequested = CloseRequested;
            if (closeRequested != null) closeRequested (this, EventArgs.Empty);
        }
    }
    //mainwinow.xaml.cs
         public MainWindow()
         {
             InitializeComponent();
             var viewModel = new MainWindowViewModel();
             viewModel.CloseRequested += (sender, args) => this.Close();
             DataContext = viewModel;
         }
