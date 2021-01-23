    public class TextBoxHelper
        {
            public static string GetWatermark(DependencyObject obj)
            {
                return (string)obj.GetValue(WatermarkProperty);
            }
    
            public static void SetWatermark(DependencyObject obj, string value)
            {
                obj.SetValue(WatermarkProperty, value);
            }
    
            public static readonly DependencyProperty WatermarkProperty =
                DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(TextBoxHelper), new UIPropertyMetadata(string.Empty));
        }
