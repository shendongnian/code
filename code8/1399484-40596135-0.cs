        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += OnTextBoxGotFocus;
            AssociatedObject.TextChanged += OnTextBoxTextChanged;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= OnTextBoxGotFocus;
            AssociatedObject.TextChanged -= OnTextBoxTextChanged;
            base.OnDetaching();
        }
        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            AssociatedObject.SelectAll();
        }
        private void OnTextBoxTextChanged(object sender, RoutedEventArgs e)
        {
            AssociatedObject.SelectAll();
            AssociatedObject.TextChanged -= OnTextBoxTextChanged;
        }
