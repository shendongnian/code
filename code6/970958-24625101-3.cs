    namespace CSharpWPF
    {
        public class CalendarHelper : DependencyObject
        {
            public static CalendarMode GetDisplayMode(DependencyObject obj)
            {
                return (CalendarMode)obj.GetValue(DisplayModeProperty);
            }
            public static void SetDisplayMode(DependencyObject obj, CalendarMode value)
            {
                obj.SetValue(DisplayModeProperty, value);
            }
            // Using a DependencyProperty as the backing store for DisplayMode.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty DisplayModeProperty =
                DependencyProperty.RegisterAttached("DisplayMode", typeof(CalendarMode), typeof(CalendarHelper), new PropertyMetadata(CalendarMode.Month, OnModeChanged));
            private static void OnModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Calendar cal = d as Calendar;
                cal.IsKeyboardFocusWithinChanged += (ss, ee) => cal.SetValue(Calendar.DisplayModeProperty, e.NewValue);
            }
        }
    }
