    public class SomeController : ApiController
    {
        [OverrideAuthentication]
        public HttpResponeMessage Login(Dto dto)
        { }
    }
