    public class EntitiesController : ApiController
    {
        [ValidateModel]
        public HttpResponseMessage Post(SampleEntity entity)
        {
            // ...
        }
    }
