    public class YourBehavior
    {
        public static readonly DependencyProperty YourCanHideProperty = DependencyProperty.RegisterAttached(
                    "YourCanHide",
                    typeof(bool),
                    typeof(LayoutAnchorable),
                    new PropertyMetadata(YourCanHidePropertyChanged));
        private static void YourCanHidePropertyChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            LayoutAnchorable control = dependencyObject as LayoutAnchorable;
            if (control != null)
            {
                control.CanHide = e.NewValue as bool;
            }
        }
        public static bool GetYourCanHideProperty(LayoutAnchorablewindow)
        {
            return window.GetValue(YourProperty) as bool?;
        }
        public static void SetYourCanHideProperty(LayoutAnchorable control, bool value)
        {
            window.SetValue(YourProperty, value);
        }
    }
