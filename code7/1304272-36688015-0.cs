     public static class CustomCommands
     {
            public static readonly RoutedUICommand Exit = new RoutedUICommand
                    (
                            "Beenden",
                            "Exit",
                            typeof(CustomCommands),
                            new InputGestureCollection()
                            {
                                new KeyGesture(Key.F4, ModifierKeys.Alt)
                            }
                    );
     }
    public partial class MainWindow : Window
    {
        public  CustomCommands CM;
        public MainWindow()
        {
            CM = new  CustomCommands();
            InitializeComponent();
            this.DataContext = CM;
        }
        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(e != null)
                e.CanExecute = true;
        }
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
