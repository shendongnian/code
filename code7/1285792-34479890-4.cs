    namespace MyHelpers
    {
        public class HolidayHelper
        {
            public static DateTime GetDate(DependencyObject obj)
            {
                return (DateTime)obj.GetValue(DateProperty);
            }
            public static void SetDate(DependencyObject obj, DateTime value)
            {
                obj.SetValue(DateProperty, value);
            }
            public static readonly DependencyProperty DateProperty =
            DependencyProperty.RegisterAttached("Date", typeof(DateTime), typeof(HolidayHelper), new PropertyMetadata { PropertyChangedCallback = DatePropertyChanged });
            private static void DatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var date = GetDate(d);
                SetIsHoliday(d, CheckIsHoliday(date));
            }
            private static bool CheckIsHoliday(DateTime date)
            {
                //here we should determine whether 'date' is a holiday
                //or not and return corresponding value
            }
            private static readonly DependencyPropertyKey IsHolidayPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly("IsHoliday", typeof(bool), typeof(HolidayHelper), new PropertyMetadata());
            public static readonly DependencyProperty IsHolidayProperty = IsHolidayPropertyKey.DependencyProperty;
            public static bool GetIsHoliday(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsHolidayProperty);
            }
            private static void SetIsHoliday(DependencyObject obj, bool value)
            {
                obj.SetValue(IsHolidayPropertyKey, value);
            }
        }
    }
