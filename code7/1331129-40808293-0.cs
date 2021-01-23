    public class RequiredDateTimeAttribute : ValidationAttribute
    {
        public RequiredDateTimeAttribute()
        {
            ErrorMessage = "The {0} field is required";
        }
    
        public override bool IsValid(object value)
        {
            if (!(value is DateTime))
                throw new ArgumentException("value must be a DateTime object");
    
            if ((DateTime)value == DateTime.MinValue)
                return false;
    
            return true;
        }
    
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
 
