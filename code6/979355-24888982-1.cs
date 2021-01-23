    namespace CSharpWPF
    {
        class ScrollHelper : DependencyObject
        {
            public static bool GetSelectScroll(DependencyObject obj)
            {
                return (bool)obj.GetValue(SelectScrollProperty);
            }
            public static void SetSelectScroll(DependencyObject obj, bool value)
            {
                obj.SetValue(SelectScrollProperty, value);
            }
            // Using a DependencyProperty as the backing store for SelectScroll.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SelectScrollProperty =
                DependencyProperty.RegisterAttached("SelectScroll", typeof(bool), typeof(ScrollHelper), new PropertyMetadata(false, OnSelectScroll));
            private static void OnSelectScroll(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                TabItem tab = d as TabItem;
                if ((bool)e.NewValue)
                {
                    tab.BringIntoView();
                }
            } 
        }
    }
