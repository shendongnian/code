    using System;
    using System.Text.RegularExpressions;
    public static bool IsValidEmail(string strIn)
    {
       // Return true if strIn is in valid e-mail format.
          return Regex.IsMatch(strIn, 
          @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
          + "@"
          + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"); 
    }
