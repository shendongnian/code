        public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.WriteLine("header 1");
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_CanExecute_P(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_Executed_P(object sender, ExecutedRoutedEventArgs e)
        {
            Debug.WriteLine("panda");
        }
    }
    public class EditCommands
    {
        public static RoutedUICommand Header1 { get; private set; }
        public static RoutedUICommand PandaButton
        {
            get;
            private set;
        }
        static EditCommands()
        {
            var gestures = new InputGestureCollection {new KeyGesture(Key.D1, ModifierKeys.Control, "Ctrl+1")};
            Header1 = new RoutedUICommand("Header 1", "Header1", typeof(EditCommands), gestures);
            var pandaG = new InputGestureCollection { new KeyGesture(Key.D2, ModifierKeys.Control, "Ctrl+2") };
            PandaButton = new RoutedUICommand("Panda Button", "PandaButton", typeof(EditCommands), gestures);
        }
    }
