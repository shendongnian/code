        public void ConfigureServices(IServiceCollection services)
        {
            //...
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
        public class ModelStateTagHelper : TagHelper
        {
            public readonly IActionContextAccessor _accessor;
            
            public ModelStateTagHelper(IActionContextAccessor accessor)
            {
                _accessor = accessor;
            }
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                var modelState = _accessor.ActionContext.ModelState;
            }
        }
