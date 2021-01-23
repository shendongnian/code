    public class GroupIDToGroupName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                SampleDBContext sampleDBContext = new SampleDBContext();
                return (from g in sampleDBContext.Groups
                        where g.GroupID == (int)value
                        select g.GroupName).FirstOrDefault();
            }
            else
            {
                return "";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SampleDBContext sampleDBContext = new SampleDBContext();
            return (from g in sampleDBContext.Groups
                    where g.GroupName == (string)value
                    select g.GroupID).FirstOrDefault();
        }
    }
