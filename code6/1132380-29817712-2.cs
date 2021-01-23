    public partial class MainWindow : Window
    {
        public static readonly RoutedCommand OptionsCommand = new RoutedUICommand("Options", "OptionsCommand", typeof(MainWindow), new InputGestureCollection(new InputGesture[]
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            }));
        //...
    }
