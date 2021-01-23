        public static readonly DependencyProperty FocusFirstProperty =
            DependencyProperty.RegisterAttached("FocusFirst", typeof(bool), 
               typeof(ListViewExtension), new PropertyMetadata(false, HandleFocusFirstChanged));
     static void HandleFocusFirstChanged(
      DependencyObject depObj, DependencyPropertyChangedEventArgs e)
      {
      }
