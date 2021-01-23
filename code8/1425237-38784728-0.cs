    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyPhoneAttribute : RegularExpressionAttribute
    {
        private const string nineDigitsPattern = @"^([0-9]{9}){0,1}$";
    	private const string sameNumberPattern = @"(\w)\1{9,}";
    
        public MyPhoneAttribute () : base(myRegex )
        {
            ErrorMessage = "default error message";
        }
    
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty(value as string))
                return true;
    		
    		// case 1
    		if (Regex.IsMatch(value.ToString(), nineDigitsPattern))
            {
    			ErrorMessage = "error message 1";
                return false;
            }
    		
    		// case 2
    		if (Regex.IsMatch(value.ToString(), sameNumberPattern))
            {
    			ErrorMessage = "error message 2";
                return false;
            }
    		
    		// case 3		
            if (value.ToString().Equals("123456789"))
            {
    			ErrorMessage = "error message 3";
                return false;
            }
    
    		// case 4
            if (value.ToString().StartsWith("0"))
            {
    			ErrorMessage = "error message 4";
                return false;
            }
    		
    		return true;
        }
    }
