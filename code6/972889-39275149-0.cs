    using System.Collections.ObjectModel;
    private Collection<ApiDescription> FilteredDescriptions()
    {
        var desctiptionsToShow = new Collection<ApiDescription>();
        foreach (var apiDescription in Configuration.Services.GetApiExplorer().ApiDescriptions)
        {
            var actionDescriptor = apiDescription.ActionDescriptor as ReflectedHttpActionDescriptor;
            var authAttribute = actionDescriptor?.MethodInfo.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == nameof(System.Web.Http.AuthorizeAttribute));
            var roleArgument = authAttribute?.NamedArguments?.FirstOrDefault(x => x.MemberName == nameof(System.Web.Http.AuthorizeAttribute.Roles));
            var roles = roleArgument?.TypedValue.Value as string;
            if (roles?.Split(',').Any(role => User.IsInRole(role.Trim())) ?? false)
            {
                desctiptionsToShow.Add(apiDescription);
            }
        }
        return desctiptionsToShow;
    }
