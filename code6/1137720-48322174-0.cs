    public class PhoneNumberValidator
    {
        public string ErrorMessage { get; set; }
	    public int PhoneNumberDigits { get; set; }
	    public string CachedPhoneNumber { get; set; }
        private Dictionary<int, string> VaildAreaCodes()
        {
            return new Dictionary<int, string>
            {
                [3] = "0",
                [4] = "27"
            };
        }
        private bool IsInteger(string value)
        {
            return int.TryParse(value, out int result);
        }
        private string GetConsecutiveCharsInPhoneNumberStr(string phoneNumber)
        {
            switch (PhoneNumberDigits)
            {
                case 0:
                case 10:
                    PhoneNumberDigits = 10;
                    return phoneNumber.Substring(phoneNumber.Length - 7);
                case 11:
                    return phoneNumber.Substring(phoneNumber.Length - 8);
                default:
                    return string.Empty;
            }
        }
        private bool IsValidAreaCode(ref string phoneNumber, string areaCode)
        {
            if (!IsInteger(areaCode))
            {
                ErrorMessage = "Area code characters of Phone Number value should only contain integers.";
                return false;
            }
            var areaCodeLength = areaCode.Length;
            switch (areaCodeLength)
            {
                case 2:
                    phoneNumber = string.Concat("0", phoneNumber);
                    return true;
                case 3:                    
                    return areaCode.StartsWith(VaildAreaCodes()[3]);
                case 4:
                    if (areaCode.StartsWith(VaildAreaCodes()[4]))
                    {
                        phoneNumber = string.Concat("0", phoneNumber.Remove(0, 2));
                        return true;
                    }
                    return false;                
                default:
                    ErrorMessage = "Phone Number value contains invalid area code.";
                    return false;
            }
        }	
        public bool IsValidPhoneNumber(ref string phoneNumber)
        {
            CachedPhoneNumber = phoneNumber;
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                ErrorMessage = "Phone Number value should not be equivalent to null.";
                return false;
            }
            phoneNumber = Regex.Replace(phoneNumber, " {2,}", string.Empty); // remove all whitespaces
            phoneNumber = Regex.Replace(phoneNumber, "[^0-9]", string.Empty); // remove all non numeric characters
            var lastConsecutiveCharsInPhoneNumberStr = GetConsecutiveCharsInPhoneNumberStr(phoneNumber);
            if (string.IsNullOrWhiteSpace(lastConsecutiveCharsInPhoneNumberStr))
            {
                ErrorMessage = "Phone Number value not supported.";
                return false;
            }
            if (!IsInteger(lastConsecutiveCharsInPhoneNumberStr))
            {
                ErrorMessage = "Last consecutive characters of Phone Number value should only contain integers.";
                return false;
            }
            var phoneNumberAreaCode = phoneNumber.Replace(lastConsecutiveCharsInPhoneNumberStr, "");
            if (!IsValidAreaCode(ref phoneNumber, phoneNumberAreaCode))
            {
                return false;
            }            
            if (phoneNumber.Length != PhoneNumberDigits)
            {
                ErrorMessage = string.Format("Phone Number value should contain {0} characters instead of {1} characters.", PhoneNumberDigits, phoneNumber.Length);
                return false;
            }
            return true;
        }
    }
