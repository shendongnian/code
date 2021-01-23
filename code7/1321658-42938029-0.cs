    public abstract class EnumToIntConverter<TEnum> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Enum)
                return (int)value;
            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
                return (TEnum)value;
            return DependencyProperty.UnsetValue;
        }
    }
    public sealed class MyEnumToIntConverter : EnumToIntConverter<MyEnum>
    {
        //Do nothing!
    }
