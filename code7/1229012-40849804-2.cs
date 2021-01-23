    public class Client
    {
        public string TelephoneNumber {get; set;}
    
        //Require 10 digits, each surrounded by any non-digit characters (will strip all non-digits)
        [RegularExpression(@"(\D*\d\D*){10}", ErrorMessage = "Please enter a 10 digit phone number")]
        public string FormattedPhoneNum
        {
            get
            {
                MyHelpers.FormatPhoneNumber(TelephoneNumber);
            }
            set
            {
                TelephoneNumber = MyHelpers.StripPhoneNumber(value);
            }
        }
    }
    public class MyHelpers
    {
        public static StripPhoneNumber(string phone)
        {
            if (phone == null)
                return phone;
            else
                return _nonDigits.Replace(phone, String.Empty);
        }
    
        public static string FormatPhoneNumber(string phoneNum)
        {
            phoneNum = StripPhoneNumber(phoneNum);
    
            if (String.IsNullOrEmpty(phoneNum)) return phoneNum;
            
            return Regex.Replace(phoneNum, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");  //US Phone Number
        }
    }
