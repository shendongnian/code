    static class TooltipHelper
    {
        public static readonly DependencyProperty TargetOfProperty =
            DependencyProperty.RegisterAttached("TargetOf", typeof(Label),
            typeof(TooltipHelper), new PropertyMetadata(null, _OnTargetOfChanged));
        public static void SetTargetOf(FrameworkElement target, Label labelElement)
        {
            target.SetValue(TargetOfProperty, labelElement);
        }
        public static Label GetTargetof(FrameworkElement target)
        {
            return (Label)target.GetValue(TargetOfProperty);
        }
        private static void _OnTargetOfChanged(
            DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Label oldLabel = (Label)e.OldValue,
                newLabel = (Label)e.NewValue;
            if (oldLabel != null)
            {
                BindingOperations.ClearBinding(oldLabel, Label.TargetProperty);
                BindingOperations.ClearBinding(target, FrameworkElement.ToolTipProperty);
            }
            if (newLabel != null)
            {
                Binding binding = new Binding();
                binding.Source = newLabel;
                binding.Path = new PropertyPath("Content");
                binding.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(
                    target, FrameworkElement.ToolTipProperty, binding);
                binding = new Binding();
                binding.Source = target;
                binding.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(
                    newLabel, Label.TargetProperty, binding);
            }
        }
    }
