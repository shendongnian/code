        public static string FindAge(string DateOfBirth)
        {
            DateTime Birthdate = new DateTime();
            DateTime.TryParse(DateOfBirth, out Birthdate);
            TimeSpan TempAge = DateTime.Now - Birthdate;
            int Years = (int)TempAge.TotalDays / 365;
            return Years.ToString();
        }
