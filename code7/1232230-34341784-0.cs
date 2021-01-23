        public static Brush GetNullAccentBrush(DependencyObject d)
        {
            return (Brush)d.GetValue(NullAccentBrushProperty);
        }
        public static void SetNullAccentBrush(DependencyObject d, Brush value)
        {
            d.SetValue(NullAccentBrushProperty, value);
        }
        public static readonly DependencyProperty NullAccentBrushProperty = DependencyProperty.RegisterAttached(
            "NullAccentBrush",
            typeof(SolidColorBrush),
            typeof(MySettings),
            null
            );
