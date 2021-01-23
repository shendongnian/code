    [HeaderInjectionFilter]
    public class MotionTypeController : ApiController
    {
        public bool Get()
        {
            return this.Request.Headers.GetValues("test").Any();
        }
    }
