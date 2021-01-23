        public static string IndexNumber2YrTo4Yr(string inp)
        {
            if (inp == null)
            {
                throw new ArgumentNullException("inp");
            }
            string[] parts;
            parts = inp.Split('/');
            if (
                parts.Length != 2 ||
                parts[0].Length != 5 ||
                parts[1].Length != 2
            )
            {
                throw new ArgumentException("Index number invalid", "inp");
            }
            int twoDigitYear = 0;
            try
            {
                twoDigitYear = Convert.ToInt32(parts[1]);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Year invalid", "inp", e);
            }
            return string.Format("{0}/{1:0000}", parts[0], YearTwoDigitToFourDigit(twoDigitYear));
        }
        public static int YearTwoDigitToFourDigit(int twoDigitYear)
        {
            if (twoDigitYear < 0 || twoDigitYear > 99)
            {
                throw new ArgumentOutOfRangeException("twoDigitYear");
            }
            // Do we like these rules? Or should we define them.
            return CultureInfo.InvariantCulture.Calendar.ToFourDigitYear(twoDigitYear);
        }
