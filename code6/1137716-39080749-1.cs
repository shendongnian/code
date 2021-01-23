       /// <summary>
        /// Allows phone number of the format: NPA = [2-9][0-8][0-9] Nxx = [2-9]      [0-9][0-9] Station = [0-9][0-9][0-9][0-9]
        /// </summary>
        /// <param name="strPhone"></param>
        /// <returns></returns>
        public static bool IsValidUSPhoneNumber(string strPhone)
        {
            string regExPattern = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
            return MatchStringFromRegex(strPhone, regExPattern);
        }
        // Function which is used in IsValidUSPhoneNumber function
        public static bool MatchStringFromRegex(string str, string regexstr)
        {
            str = str.Trim();
            System.Text.RegularExpressions.Regex pattern = new System.Text.RegularExpressions.Regex(regexstr);
            return pattern.IsMatch(str);
        }
