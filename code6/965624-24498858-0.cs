    public static class MouseCommands
    {
        private static void LeftDoubleClickChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var control = (Control)sender;
            if (args.NewValue != null && args.NewValue is ICommand)
            {
                var newBinding = new MouseBinding(args.NewValue as ICommand, new MouseGesture(MouseAction.LeftDoubleClick));
                control.InputBindings.Add(newBinding);
            }
            else
            {
                var oldBinding = control.InputBindings.Cast<InputBinding>().First(b => b.Command.Equals(args.OldValue));
                control.InputBindings.Remove(oldBinding);
            }
        }
        public static readonly DependencyProperty LeftDoubleClickProperty =
            DependencyProperty.RegisterAttached("LeftDoubleClick",
                typeof(ICommand),
                typeof(MouseCommands),
                new UIPropertyMetadata(LeftDoubleClickChanged));
        public static void SetLeftDoubleClick(DependencyObject obj, ICommand value)
        {
            obj.SetValue(LeftDoubleClickProperty, value);
        }
        public static ICommand GetLeftDoubleClick(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(LeftDoubleClickProperty);
        }
    }
