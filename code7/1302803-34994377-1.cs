    public class MyClassToStringValueConverter : IValueConverter
    {
        private static FieldInfo Name1Field;
        private static FieldInfo Name2Field;
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Name1Field == null)
            {
                Name1Field = typeof(MyClass).GetField("Name1", BindingFlags.NonPublic | BindingFlags.Instance);
            }
            if (Name2Field == null)
            {
                Name2Field = typeof(MyClass).GetField("Name2", BindingFlags.NonPublic | BindingFlags.Instance);
            }
            return string.Format("{0} {1}", Name1Field.GetValue(value), Name2Field.GetValue(value));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
	
