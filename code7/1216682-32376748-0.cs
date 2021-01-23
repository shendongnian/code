    public class ValuesController : ApiController
    {
        private readonly IValueProvider _valueProvider;
    
        public ValuesController(IValueProvider valueProvider)
        {
            _valueProvider = valueProvider;
        }
    
        // the rest of code here
    }
