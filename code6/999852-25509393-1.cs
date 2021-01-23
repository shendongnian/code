    class MyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, 
            object parameter, System.Globalization.CultureInfo culture)
        {
            MyCommandArgs result = new MyCommandArgs()
            {
                MyList = values[0] as IList<MyClass>,
                CurrentItem = values[1] as MyClass
            };
            return result;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, 
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
