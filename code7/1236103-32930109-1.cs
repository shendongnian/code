    namespace WpfCommands
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            DataModel dm = new DataModel();
            
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = true;
            }
    
            private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                Validator myValidator = new Validator();
    
                dm.Validate(myValidator);
                if (myValidator.Errors.Count > 0)
                {
                    MessageBox.Show("Errors !");
                    // do something with errors
                }
            }
        }
    }
