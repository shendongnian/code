        [TestMethod]
        public void TestListComparer()
        {
            var list1 = new List<ScheduleDetail> { 
                new ScheduleDetail { HomeHelpID = 1},
                new ScheduleDetail { HomeHelpID = 3}
            };
            var list2 = new List<ScheduleDetail> { 
                new ScheduleDetail { HomeHelpID = 1},
                new ScheduleDetail { HomeHelpID = 5}
            };
            var comparison = SuperDuperListComparer.CompareLists(list1, list2, new CompareSchedules());
        }
        public class ScheduleDetail
        {
            public int HomeHelpID { get; set; }
        }
