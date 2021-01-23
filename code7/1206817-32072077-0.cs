    public static class MyValidator
    {
      protected static PhoneNumberRegex = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$");
      protected static EmailRegex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$.");  
    
      public static bool ValidatePhoneNumber(string strToMatch)
      {
        return PhoneNumberRegex.IsMatch(strToMatch);
      }
    
      public static bool ValidateEmail(string strToMatch)
      {
        return EmailRegex.IsMatch(strToMatch);
      }
    }
