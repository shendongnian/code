    namespace Desktop
    {
      public partial class MainWindow : Window
      {
        public MainWindow() { InitializeComponent(); }
    
        private void MainWindow_OnDeactivated(object sender, EventArgs eventArgs)
        {
          Activate();
        }
      }
    }
