    using System.Windows.Controls;
    using System.Windows.Interactivity;
    public class TrimTextBoxBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.LostFocus += AssociatedObject_LostFocus;
        }
        private void AssociatedObject_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            AssociatedObject.Text = AssociatedObject.Text.Trim();
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.LostFocus -= AssociatedObject_LostFocus;
        }
    }
