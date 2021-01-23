     public class Helper
    {
        public static Brush GetReadonlyBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ReadonlyBackgroundProperty);
        }
        public static void SetReadonlyBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(ReadonlyBackgroundProperty, value);
        }
        public static readonly DependencyProperty ReadonlyBackgroundProperty =
            DependencyProperty.RegisterAttached("ReadonlyBackground", typeof(Brush), typeof(Helper), new PropertyMetadata(null));
    }
