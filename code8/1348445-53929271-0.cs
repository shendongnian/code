    using System.Web.Mvc;
    namespace WebApplication1.Controllers
    {
        extern alias Alias1;
        extern alias Alias2;
        using namespace1 = Alias1::System.Net.Http.HttpRequestMessageExtensions;
        using namespace2 = Alias2::System.Net.Http.HttpRequestMessageExtensions;
        public class HomeController : Controller
        {
            public void Test()
            {
                // ...
                namespace1.GetRequestContext(request);
                //namespace2.GetRequestContext(request); // error
           
            }
