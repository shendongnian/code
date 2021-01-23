    public class MyTextBox : TextBox
    {
        public event EventHandler<RoutedEventArgs> ExtraClick;
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button extraButton = GetTemplateChild("ExtraButton") as Button;
            if (extraButton != null)
            {
                extraButton.Click += (sender, e) => ExtraClick?.Invoke(sender, e);
            }
        }
    }
