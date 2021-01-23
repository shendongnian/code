    public class SampleWebController : ApiController
    {
        [ActionName("SampleAction")]
        public object SampleAction(int id)
        {
            return id;
        }
     }
