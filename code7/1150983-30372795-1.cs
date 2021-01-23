    var path = "~/Views/Home/Index.cshtml";
    var viewDataDictionary = new ViewDataDictionary(new Microsoft.AspNet.Mvc.ModelBinding.EmptyModelMetadataProvider(), new Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary());
    var actionContext = new ActionContext(httpContextAccessor.HttpContext, new Microsoft.AspNet.Routing.RouteData(), new ActionDescriptor());
    viewDataDictionary.Model = null;
    var text = await RenderView(path, viewDataDictionary, actionContext);
