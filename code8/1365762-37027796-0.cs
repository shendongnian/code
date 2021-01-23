    public object Convert(object value, Type targetType, object parameter, string language)
    {
    	if (parameter == null)
    		return value;
    
    	Double val;
    	Double param;
    
    	if (Double.TryParse(value.ToString(), out val) && Double.TryParse(parameter.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out param))
    	{
    		switch (Mode)
    		{
    			case (ArithmeticMode.Addition):
    				return val + param;
    			case (ArithmeticMode.Subtratction):
    				return val - param;
    			case (ArithmeticMode.Multiplication):
    				return val * param;
    			case (ArithmeticMode.Division):
    				return val / param;
    			default:
    				return val;
    		}
    	}
    	else
    		return value;
    }
