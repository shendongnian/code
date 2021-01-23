     public sealed class OptionalPhoneAttribute : ValidationAttribute
     {        
        public override bool IsValid(object value)
        {
            var phone = new PhoneAttribute();
            //return true when the value is null or empty
            //return original IsValid value only when value is not null or empty 
            return (value == null || string.IsNullOrEmpty(Convert.ToString(value)) || phone.IsValid(value));
        }
    }
