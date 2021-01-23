    public class RequestModel()
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public MyWebApiController : ApiController
    {
        public object Post(RequestModel model)
        {
            // Do something
            // Return same values back
            return model;
        }
    }
