    [Test, TestCase(1), TestCase(9)]
        public void Test(int month)
        {
            var serverTime = new DateTime(2015, month, 18, 10, 14, 09);
            // No Daylight saving in Russia
            var serverTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            // Daylight saving in Atlanta
            var localTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Atlantic Standard Time");
            // check if ConvertTime take care of daylight saving
            var localTime = TimeZoneInfo.ConvertTime(serverTime, serverTimeZone, localTimeZone);
            // it does
            if (localTimeZone.IsDaylightSavingTime(localTime))
                Assert.AreEqual(string.Format("{0}/18/15 04:14 AM", month), localTime.ToString("M/dd/yy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture));
            else
                Assert.AreEqual(string.Format("{0}/18/15 03:14 AM", month), localTime.ToString("M/dd/yy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture));
        }
