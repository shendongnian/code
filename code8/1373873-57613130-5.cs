    public class MessageCenterController : Controller
    {
        private readonly MyOptions _options;
        private readonly IMyHelper _myHelper;
    
        public MessageCenterController(
            IOptions<MyOptions> options,
            IMyHelper myHelper
        )
        {
            _options = options.value;
            _myHelper = myHelper;
        }
    
        public void DoSomething()
        {
            if (_myHelper.CheckIt())
            {
                // Do Something
            }
        }
    }
