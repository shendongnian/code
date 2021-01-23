    public class Pager
    {
        // Using a DependencyProperty as the backing store for PrePend.  
        //   This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedEntryProperty =
            DependencyProperty.Register("SelectedEntry", typeof(object), 
              typeof(Pager), 
              new PropertyMetadata(null, OnSelectedEntryChanged));
        public object SelectedEntry
        {
             get { return GetValue(SelectedEntryProperty); }
             set { SetValue(SelectedEntryProperty, value); }
        }
        private static void OnSelectedEntryChanged(DependencyObject pager, DependencyPropertyChangedEventArgs e) 
        {
             // TODO set the SelectedItem in the ListBox
        }
    }
