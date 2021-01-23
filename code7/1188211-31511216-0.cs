        [TestMethod]
        public void DateTimeStringDateTimeMinCurrentCultureToNullableDateTimeSuccessTest()
        {
            DateTime dateTime = new DateTime(1, 1, 1);
            string value = dateTime.ToStringInvariant();
            var result = value.ToNullableDateTime();
            Assert.AreEqual(dateTime, result);
        }
        public static string ToStringInvariant(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToStringInvariant();
            return null;
        }
        public static string ToStringInvariant(this DateTime date)
        {
            return date.ToString(CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Converts a string to a nullable DateTime. If the string is a invalid dateTime returns null.
        /// Uses the current culture.
        /// </summary>
        public static DateTime? ToNullableDateTime(this string s)
        {
            //Don't use CultureInfo.CurrentCulture to override user changes of the cultureinfo.
            return s.ToNullableDateTime(CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// Converts a string to a nullable DateTime. If the string is a invalid dateTime returns null.
        /// </summary>
        public static DateTime? ToNullableDateTime(this string s, CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty(s)) return null;
            DateTime i;
            if (DateTime.TryParse(s, cultureInfo, DateTimeStyles.None, out i)) return i;
            return null;
        }
