    public class TestResult
    {
        // Can't be 100% certain about the userId type
        // based on your code sample - adjust as necessary.
        public int userid { get; set; }
        public int total { get; set; }
    }
    var a = _db.Test
           .GroupBy(g => g.userId)
           .Select(s => new TestResult { userid = s.Key,  total = s.Count()});
