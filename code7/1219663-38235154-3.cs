    using Microsoft.Extensions.DependencyInjection;
    
    namespace Core.Controllers
    {
        public class HomeController : Controller
        {
            public HomeController(IServiceProvider serviceProvider)
            {
                var service = serviceProvider.GetService<ITestService>();
                int rnd = service.GenerateRandom();
            }
