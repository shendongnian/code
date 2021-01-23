    public class MyObject {
        public string name { get; set; }
        public int age { get; set; }
        public string country { get; set; }
    }
    [Route("")]
    [HttpPost]
    public void SaveTestRun(MyObject data) {
        inputResultsToDatabase(data);
    }
