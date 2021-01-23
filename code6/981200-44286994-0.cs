    public class MyController : Controller
    {
        private readonly IService _service;
    
        public MyController(Service service) //problem here, Iservice should be used instead
        {
            _service = service;
        }
    }
