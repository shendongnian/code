    public class ValuesController : ApiController
    {
        public SomeClass Get()
        {
            return new SomeClass();
        }
    
        public SomeClass Post([FromBody] SomeClass x)
        {
            return x;
        }
    }
