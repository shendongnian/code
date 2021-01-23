	public class NumericComparisonToBoolConverter : MarkupExtension, IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value != null && IsNumericType(value.GetType()))
			{
				var d = System.Convert.ToDouble(value);
				switch (ComparisonType)
				{
					case NumericComparisonType.IsEqualTo:
						return ComparisonNumber == d;
                    ...etc...
				}
			}
			return false;
		}
		public double ComparisonNumber { get; set; }
        public NumericComparisonType ComparisonType { get; set; }
        public enum NumericComparisonType
        {
            None = 0,
            IsEqualTo,
            IsNotEqualTo,
            IsLessThan,
            IsGreaterThan,
            ...etc...
        }
        protected bool IsNumericType(Type type)
		{
			if (type == null)
				return false;
        	switch (Type.GetTypeCode(type))
			{
				case TypeCode.Byte:
				case TypeCode.Decimal:
				case TypeCode.Double:
	            ...etc...
					return true;
				case TypeCode.Object:
					if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
					{
						return IsNumericType(Nullable.GetUnderlyingType(type));
					}
					return false;
			}
			return false;
		}
        public virtual object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
