    public static class MouseEnterBehavior
    {
        public static readonly DependencyProperty MouseEnterProperty =
           DependencyProperty.RegisterAttached("MouseEnter",
                                               typeof(ICommand),
                                               typeof(MouseEnterBehavior),
                                               new PropertyMetadata(null, MouseEnterChanged));
        public static ICommand GetMouseEnter(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(MouseEnterProperty);
        }
        public static void SetMouseEnter(DependencyObject obj, ICommand value)
        {
            obj.SetValue(MouseEnterProperty, value);
        }
        private static void MouseEnterChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiElement = obj as UIElement;
            if (uiElement != null)
                uiElement.MouseEnter += new MouseEventHandler(uiElement_MouseEnter);
        }
        static void uiElement_MouseEnter(object sender, MouseEventArgs e)
        {
            UIElement uiElement = sender as UIElement;
            if (uiElement != null)
            {
                ICommand command = GetMouseEnter(uiElement);
                command.Execute(uiElement);
            }
        }
    }
