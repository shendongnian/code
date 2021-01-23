    [TestFixture]
    public class TimeZoneTest {
        [Test]
        public void Test() {
            var serverTime = new DateTime(2015, 09, 18, 10, 14, 09);
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            var serverTimeZone = timeZones.First(x => x.Id == "Mountain Standard Time");
            var localTimeZone = timeZones.First(x => x.Id == "Atlantic Standard Time");
            var localTime = TimeZoneInfo.ConvertTime(serverTime, serverTimeZone, localTimeZone);
            Assert.AreEqual("09/18/15 01:14 PM", localTime.ToString("MM/dd/yy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
