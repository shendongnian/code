    using System.Web.Http;
    using Microsoft.Azure.Mobile.Server.Config;
    using System.Threading.Tasks;
    using System.Web.Http.Tracing;
    using Microsoft.Azure.Mobile.Server;
    namespace BCMobileAppService.Controllers
    {
    [MobileAppController]
    public class TestController : ApiController
    {
        // GET api/Test
        [HttpGet, Route("api/Test/completeAll")]
        public string Get()
        {
            MobileAppSettingsDictionary settings = this.Configuration.GetMobileAppSettingsProvider().GetMobileAppSettings();
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();
    
                string host = settings.HostName ?? "localhost";
                string greeting = "Hello from " + host;
    
                traceWriter.Info(greeting);
                return greeting;
            }
            // POST api/values
            [HttpPost, Route("api/Test/completeAll")]
            public string Post(string hej)
            {
                string retVal = "Hello World!" + hej;
                return retVal;
            }
        }
    }
