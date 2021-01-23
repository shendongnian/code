        internal static bool IsValidPhoneNumber(this string This)
        {
            var phoneNumber = This.Trim()
                .Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "");
            return Regex.Match(phoneNumber, @"^\+\d{5,15}$").Success;
        }
