    class TimeConverter : IMultiValueConverter
    {
        public string Format { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime utc = (DateTime)values[0];
            TimeZoneInfo tzi = (TimeZoneInfo)values[1];
            return tzi != null ? TimeZoneInfo.ConvertTime(utc, tzi).ToString(Format) : Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string timeText = (string)value;
            DateTime time;
            if (!DateTime.TryParseExact(timeText, Format, null, DateTimeStyles.None, out time))
            {
                return new object[] { Binding.DoNothing, Binding.DoNothing };
            }
            ComboBox comboBox = (ComboBox)parameter;
            TimeZoneInfo tzi = (TimeZoneInfo)comboBox.SelectedValue;
            return new object[] { TimeZoneInfo.ConvertTime(time, tzi, TimeZoneInfo.Utc), Binding.DoNothing };
        }
    }
