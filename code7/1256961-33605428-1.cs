    public class TestController : ApiController
    {
        private ITestManager TestManager { get; set; }
    
        public TestController(ITestManager testManager)
        {
            TestManager = testManager;
        }
    
    	// GET: api/Test
    	public IEnumerable<string> Get()
    	{
    		return this.TestManager.Get();
    	}
    }
