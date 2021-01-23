    public class VisualStateApplier
    {
    
        public static string GetVisualState(DependencyObject target)
        {
            return target.GetValue(VisualStateProperty) as string;
        }
        public static void SetVisualState(DependencyObject target, string value)
        {
            target.SetValue(VisualStateProperty, value);
        }
    
        public static readonly DependencyProperty VisualStateProperty =
            DependencyProperty.RegisterAttached("VisualState", typeof(string), typeof(VisualStateApplier), new PropertyMetadata(VisualStatePropertyChangedCallback));
    
        private static void VisualStatePropertyChangedCallback(DependencyObject target, DependencyPropertyChangedEventArgs args)
        {
            VisualStateManager.GoToElementState((FrameworkElement)target, args.NewValue as string, true); // <- for UIElements, OR:
            //VisualStateManager.GoToState((FrameworkElement)target, args.NewValue as string, true); // <- for Controls
        }
    }
