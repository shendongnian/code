    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MyPhoneAttribute : ValidationAttribute
    {
        private const string nineDigitsPattern = @"^([0-9]{9}){0,1}$";
      	private const string sameNumberPattern = @"(\w)\1{9,}"; // here 9 the same numbers
       
        public override bool IsValid(object value)
        {
            var validationNumber = (string)value;
    
    		if (string.IsNullOrEmpty(validationNumber))
    			return true;
    
    		// case 4
    		if (validationNumber.StartsWith("0"))
    		{
    			ErrorMessage = "error message 4";
    			return false;
    		}
        
    		// case 3       
    		if (validationNumber.Equals("123456789"))
    		{
    			ErrorMessage = "error message 3";
    			return false;
    		}
        
    		// case 2
    		if (Regex.IsMatch(validationNumber, sameNumberPattern)) {
    			ErrorMessage = "error message 2";
    			return false;
    		}
        
    		// case 1
    		if (Regex.IsMatch(validationNumber, nineDigitsPattern))
    		{
    			ErrorMessage = "error message 1";
    			return false;
    		}
        
    		return true;
        }
     }
