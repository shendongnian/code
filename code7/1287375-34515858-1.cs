    using Microsoft.Extensions.OptionsModel;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    public class CoreDataController : Controller
    {
        public CoreDataController(
            IOptions<UIOptions> uiOptionsAccessor
            )
        {
            
            uiOptions = uiOptionsAccessor.Value;
        }
        private UIOptions uiOptions;
		
    }
