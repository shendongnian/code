    using Microsoft.Extensions.DependencyInjection;
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        var service = context.ActionContext.HttpContext.RequestServices.GetService<IService>();
    }
