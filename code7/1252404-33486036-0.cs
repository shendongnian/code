    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CamelCaseJsonFormatterResourceFilter : Attribute, IResourceFilter
    {
        private readonly JsonSerializerSettings serializerSettings;
    
        public CamelCaseJsonFormatterResourceFilter()
        {
            // Since the contract resolver creates the json contract for the types it needs to deserialize/serialize,
            // cache it as its expensive
            serializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
    
        }
    
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // remove existing input formatter and add a new one
            var camelcaseInputFormatter = new JsonInputFormatter(serializerSettings);
            var inputFormatter = context.InputFormatters.FirstOrDefault(frmtr => frmtr is JsonInputFormatter);
            if (inputFormatter != null)
            {
                context.InputFormatters.Remove(inputFormatter);
                context.InputFormatters.Add(camelcaseInputFormatter);
            }
    
            // remove existing output formatter and add a new one
            var camelcaseOutputFormatter = new JsonOutputFormatter(serializerSettings);
            var outputFormatter = context.OutputFormatters.FirstOrDefault(frmtr => frmtr is JsonOutputFormatter);
            if (outputFormatter != null)
            {
                context.OutputFormatters.Remove(outputFormatter);
                context.OutputFormatters.Add(camelcaseOutputFormatter);
            }
        }
    }
    
    // Here I am using the filter to indicate that only the Index action should give back a camelCamse response
    public class HomeController : Controller
    {
        [CamelCaseJsonFormatterResourceFilter]
        public Person Index()
        {
            return new Person() { Id = 10, AddressInfo = "asdfsadfads" };
        }
    
        public Person Blah()
        {
            return new Person() { Id = 10, AddressInfo = "asdfsadfads" };
        }
