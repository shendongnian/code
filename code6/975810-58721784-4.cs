    public sealed class BoolToVisibilityConverter : IValueConverter
    {
	   public Visibility TrueValue { get; set; }
	   public Visibility FalseValue { get; set; }
	   public BoolToVisibilityConverter()
	   {
		  // Set defaults
		  this.TrueValue = Visibility.Visible;
		  this.FalseValue = Visibility.Collapsed;
	   }
	   public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	   {
		   bool flag = false;
		   if (value is bool)
		   {
			  flag = (bool)value;
		   }
		   else if (value is bool?)
		   {
			  bool? nullable = (bool?)value;
			  flag = nullable.HasValue ? nullable.Value : false;
		  }
		  return flag ? this.TrueValue : this.FalseValue;
	  }
	  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	  {
		  if (object.Equals(value, this.TrueValue))
			  return true;
		  if (object.Equals(value, this.FalseValue))
			return false;
		  return null;
      }
	}
