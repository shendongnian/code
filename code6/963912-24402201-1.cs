    namespace CSharpWPF
    {
        public class MyEventHandler
        {
            public static ICommand GetClosingCommand(DependencyObject obj)
            {
                return (ICommand)obj.GetValue(ClosingCommandProperty);
            }
            public static void SetClosingCommand(DependencyObject obj, ICommand value)
            {
                obj.SetValue(ClosingCommandProperty, value);
            }
            // Using a DependencyProperty as the backing store for ClosingCommand.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ClosingCommandProperty =
                DependencyProperty.RegisterAttached("ClosingCommand", typeof(ICommand), typeof(MyEventHandler), new PropertyMetadata(OnClosingCommandChanged));
            private static void OnClosingCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Window window = d as Window;
                window.Closing += (s, ee) => GetClosingCommand(d).Execute(ee);
            }
        }
    }
