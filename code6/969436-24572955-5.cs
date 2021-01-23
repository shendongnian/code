    public class PopupBehavior
    {
        public static readonly DependencyProperty IsPopupEventTransparentProperty =
            DependencyProperty.RegisterAttached("IsPopupEventTransparent",
                                                typeof(bool),
                                                typeof(PopupBehavior),
                                                new UIPropertyMetadata(false, OnIsPopupEventTransparentPropertyChanged));
        public static bool GetIsPopupEventTransparent(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPopupEventTransparentProperty);
        }
        public static void SetIsPopupEventTransparent(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPopupEventTransparentProperty, value);
        }
        private static void OnIsPopupEventTransparentPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = target as FrameworkElement;
            if ((bool)e.NewValue == true)
            {
                FrameworkElement topParent = VisualTreeHelpers.GetTopParent(element) as FrameworkElement;
                topParent.Opacity = 0.4;
                HwndSource popupHwndSource = HwndSource.FromVisual(element) as HwndSource;
                WindowHelper.SetWindowExTransparent(popupHwndSource.Handle);
            }
            else
            {
                FrameworkElement topParent = VisualTreeHelpers.GetTopParent(element) as FrameworkElement;
                topParent.Opacity = 1.0;
                HwndSource popupHwndSource = HwndSource.FromVisual(element) as HwndSource;
                WindowHelper.UndoWindowExTransparent(popupHwndSource.Handle, element);
            }
        }
    }
