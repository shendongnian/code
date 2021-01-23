    public class EventFocusAttachment
    {
        public static Control GetElementToFocus(Button button)
        {
            return (Control)button.GetValue(ElementToFocusProperty);
        }
        public static void SetElementToFocus(Button button, Control value)
        {
            button.SetValue(ElementToFocusProperty, value);
        }
        public static readonly DependencyProperty ElementToFocusProperty =
            DependencyProperty.RegisterAttached("ElementToFocus", typeof(Control),
            typeof(EventFocusAttachment), new PropertyMetadata(null, ElementToFocusPropertyChanged));
        public static void ElementToFocusPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.Click += async (s, args) =>
                {
                    var control = GetElementToFocus(button);
                    if (control != null)
                    {
                        await Task.Delay(100);
                        control.Focus(FocusState.Programmatic);
                    }
                };
            }
        }
    }
