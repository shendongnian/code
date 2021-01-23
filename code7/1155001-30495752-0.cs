        public static bool GetFocusFirst(ListView obj)
        {
            return (bool)obj.GetValue(FocusFirstProperty);
        }
        public static void SetFocusFirst(ListView obj, bool value)
        {
            obj.SetValue(FocusFirstProperty, value);
        }
        
        public static readonly DependencyProperty FocusFirstProperty =
            DependencyProperty.RegisterAttached("FocusFirst", typeof(bool), 
               typeof(ListViewExtension), new PropertyMetadata(false));
