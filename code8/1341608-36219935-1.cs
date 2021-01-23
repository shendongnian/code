    public class TestModel // put in Models folder
    {
        public string First { get; set; }
        public int Second { get; set; }
    }
    [HttpPost]
    public ActionResult Index(TestModel myData)
    {
        // do your magic
    }
