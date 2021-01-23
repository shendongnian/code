    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using LibraryApi.Services;
    using System.Dynamic;
    
    namespace LibraryApi.Controllers
    {
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            ILogger<ValuesController> _logger;
            ViewRenderService _viewRender;
            public ValuesController(ILogger<ValuesController> logger, ViewRenderService viewRender)
            {
                _logger = logger;
                _viewRender = viewRender;
            }
    
            // GET api/values
            [HttpGet]
            public string Get()
            {
                //ViewModel is of type dynamic - just for testing
                dynamic x = new ExpandoObject();
                x.Test = "Yes";
                var viewWithViewModel = _viewRender.Render("eNotify/Confirm.cshtml", x);
                var viewWithoutViewModel = _viewRender.Render("MyFeature/Test.cshtml");
                return viewWithViewModel + viewWithoutViewModel;
            }
        }
    }
