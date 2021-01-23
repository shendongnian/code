    public class Attendance
    {
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
    }
    
    [TestClass]
    public class AttendanceUser
    {
        [TestMethod]
        public void UseALambda()
        {
            var rand = new Random();
            var attendances = Enumerable.Range(0, 10).Select(x => 
                new Attendance { InTime = DateTime.Now.AddHours(-rand.Next(x)), OutTime = DateTime.Now.AddHours(rand.Next(x)) }).ToList();
    
            var total = attendances.Sum(x => (x.OutTime - x.InTime).TotalMinutes) / 60;
        }
    }
