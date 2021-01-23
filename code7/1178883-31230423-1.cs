     public class WindowBehavior : Behavior<Window>
        {
            protected override void OnAttached()
            {
                AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
            }
    
        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBox.Show("Enter from Window");
                e.Handled = true;
            }
        }
    
        protected override void OnDetaching()
        {
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }
