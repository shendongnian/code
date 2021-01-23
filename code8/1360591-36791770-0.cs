    public class TestController: Controller
    {
       private ITestRepository _testRepository;
    public TestController(ITestRepository testRepository)
    {
        _testRepository= testRepository;
    }
 
      [HttpGet]
       public IEnumerable<string> Get()
       {
             return new string[] { "value1", "value2" };
       }
    }
