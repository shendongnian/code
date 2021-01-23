You define them by inheriting from ValidationRule and overwriting Validate():
    public class TestRule : ValidationRule
	{
	    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	    {
	        string test = value as string;
	
	        if (text == null)
	        {
	            return new ValidationResult(false, "only strings are allowed");
	        }
	        else
	        {
	            return new ValidationResult(true, null);
	        }
	    }
	}
