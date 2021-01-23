            [TestMethod]
            public void TestGetDatesForNthDOWOfMonth()
            {
                List<DateTime> firstFridaysInFirstQuarterOf2017 = new List<DateTime>
        ();
                // These were determined by looking at a calendar
                firstFridaysInFirstQuarterOf2017.Add(new DateTime(2017, 1, 6));
                firstFridaysInFirstQuarterOf2017.Add(new DateTime(2017, 2, 3));
                firstFridaysInFirstQuarterOf2017.Add(new DateTime(2017, 3, 3));
                DayOfWeek dow = DayOfWeek.Friday;
                DateTime startDate = new DateTime(2017, 1, 1);
                DateTime endDate = new DateTime(2017, 3, 31);
                List<DateTime> testFirstFridaysInFirstQuarterOf2017 = 
        RoboReporterConstsAndUtils.GetDatesForNthDOWOfMonth(startDate, endDate, dow, 1);
                var firstNotSecond = 
     firstFridaysInFirstQuarterOf2017.Except(testFirstFridaysInFirstQuarterOf2017).ToList();
                var secondNotFirst = 
        testFirstFridaysInFirstQuarterOf2017.Except(firstFridaysInFirstQuarterOf2017).To
        List();
                Assert.IsTrue((firstNotSecond.Count == 0) && (secondNotFirst.Count 
        == 0));
            }
