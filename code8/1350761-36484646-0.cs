    public class MovieApiController : ApiController
    {
        private readonly IResources _resources;
        public MovieApiController(IResources resources)
        {
            _resources = resources;
        }
        public string Index()
        {
            return _resources.GetText("Color");
        }
    }
