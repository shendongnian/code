    public class ExtendedLongListSelector : Microsoft.Phone.Controls.LongListSelector
    {
        public ExtendedLongListSelector()
        {
            SelectionChanged += LongListSelector_SelectionChanged;
        }
        void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedItem = base.SelectedItem;
        }
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(LongListSelector),
                                new PropertyMetadata(null, OnSelectedItemChanged));
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var selector = (LongListSelector)d;
            selector.SelectedItem = e.NewValue;
        }   
       
        public new object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
