    public class BindingHelper
    {
        public static readonly DependencyProperty CommandParameterBindingProperty =
            DependencyProperty.RegisterAttached(
                "CommandParameterBinding", typeof(bool), typeof(BindingHelper),
                new PropertyMetadata(null, CommandParameterBindingPropertyChanged));
    
        public static bool GetCommandParameterBinding(DependencyObject obj)
        {
            return (bool)obj.GetValue(CommandParameterBindingProperty);
        }
    
        public static void SetCommandParameterBinding(DependencyObject obj, bool value)
        {
            obj.SetValue(CommandParameterBindingProperty, value);
        }
    
        private static void CommandParameterBindingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                BindingOperations.SetBinding(d, Button.CommandParameterProperty, new Binding { RelativeSource = new RelativeSource() { Mode = RelativeSourceMode.Self } });
            }
        }
    }
