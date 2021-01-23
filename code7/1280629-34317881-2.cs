    [AllowAnonymous]
    public class MyClassController : ApiController
    {
        public MyClass Get()
        {
            return new MyClass();
        }
    }
