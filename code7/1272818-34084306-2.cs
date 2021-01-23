    // using Microsoft.Extensions.Options;
    public class HomeController : Controller
    {
        private List<ExtraData> _extraData;
        public HomeController(IOptions<List<ExtraData>> extraData)
        {
            _extraData = extraData.Value;
        }
    }
