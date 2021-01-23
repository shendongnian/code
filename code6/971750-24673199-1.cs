    public static class RegexUtilities
    {
        /// <summary>
        /// Portible version of http://msdn.microsoft.com/en-us/library/01escwtf%28v=vs.110%29.aspx
        /// More permissive validation for client side.
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            if (String.IsNullOrEmpty(strIn))    
                return false;
            //Replace all unicode chars with ascii "A"
            strIn = Regex.Replace(strIn, "[^\x0d\x0a\x20-\x7e\t]", "A");
            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
