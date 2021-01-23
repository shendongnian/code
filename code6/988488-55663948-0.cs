        using System.Text.RegularExpressions; 
        public static bool CheckNumber(string strPhoneNumber)
        {
                string MatchNumberPattern = "^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                if (strPhoneNumber != null)
                {
                    return Regex.IsMatch(strPhoneNumber, MatchNumberPattern);
                }
                else
                {
                    return false;
                }
         }
