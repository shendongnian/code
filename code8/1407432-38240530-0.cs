    public class User
    {
        public static User CreateUserFromText(string firstName,string surName,string yearBirth,string monthBirth,string dayBirth)
        {
            if (firstName == null || surName == null || yearBirth == null || monthBirth == null || dayBirth == null)
                throw new ArgumentNullException(); // better tell what argument was null
            User user = new User
            {
                FirstName = firstName.Trim(),
                SurName = surName.Trim()
            };
            bool validInput = IsFirstNameValid(user.FirstName) && IsSurNameValid(user.SurName);
            DateTime dob;
            if (!validInput || !IsValidDayOfBirth(yearBirth, monthBirth, dayBirth, out dob))
                return null;
            user.DayOfBirth = dob;
            return user;
        }
        public DateTime DayOfBirth { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        private static bool IsFirstNameValid(string firstName)
        {
            return firstName?.Length >= 1 && firstName?.Length <= 30;
        }
        private static bool IsSurNameValid(string surName)
        {
            return surName?.Length >= 1 && surName?.Length <= 30;
        }
        private static bool IsValidDayOfBirth(string year, string month, string day, out DateTime dayOfBirth)
        {
            DateTime dob;
            bool validDayOfBirth = DateTime.TryParseExact("yyyy-MM-dd", $"{year}-{month}-{day}", null, DateTimeStyles.None, out dob);
            dayOfBirth = validDayOfBirth ? dob : DateTime.MinValue;
            return validDayOfBirth;
        }
    }
