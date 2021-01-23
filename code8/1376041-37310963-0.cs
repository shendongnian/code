    public static class CalendarViewHelper
    {
        public static IList<DateTimeOffset> GetSelectedDates(DependencyObject obj)
        {
            return (IList<DateTimeOffset>)obj.GetValue(SelectedDatesProperty);
        }
    
        public static void SetSelectedDates(DependencyObject obj, IList<DateTimeOffset> value)
        {
            obj.SetValue(SelectedDatesProperty, value);
        }
    
        public static readonly DependencyProperty SelectedDatesProperty =
            DependencyProperty.RegisterAttached("SelectedDates", typeof(IList<DateTimeOffset>), typeof(CalendarView), 
                new PropertyMetadata(null, (d, e) =>
                {
                    var cv = d as CalendarView;
                    var dates = e.NewValue as IList<DateTimeOffset>;
    
                    if (cv != null && dates != null)
                    {
                        foreach (var date in dates)
                        {
                            cv.SelectedDates.Add(date);
                        }
                    }
                }));
    }
    <CalendarView local:CalendarViewHelper.SelectedDates="{x:Bind Dates, Mode=OneWay}" />
