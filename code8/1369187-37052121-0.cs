    public class TestController : ApiController
    {
        public MyClass PostMethod([FromBody]MyClass id)
        {            
            id.Value++;
            return id;
        }
    }
    public class MyClass
    {
        public int Value {get;set;}
    }
