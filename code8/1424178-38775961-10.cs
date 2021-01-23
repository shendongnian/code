    using System;
    using System.IO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewEngines;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    public interface IViewRenderingService
    {
        string RenderPartialView(ActionContext context, string name, object model = null);
    }
    public class ViewRenderingService : IViewRenderingService
    {
        private readonly ICompositeViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        public ViewRenderingService(ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider)
        {
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
        }
        public string RenderPartialView(ActionContext context, string name, object model)
        {
            var viewEngineResult = _viewEngine.FindView(context, name, false);
            if (!viewEngineResult.Success)
            {
                throw new InvalidOperationException(string.Format("Couldn't find view '{0}'", name));
            }
            var view = viewEngineResult.View;
            using (var output = new StringWriter())
            {
                var viewContext = new ViewContext(
                    context,
                    view,
                    new ViewDataDictionary(
                        new EmptyModelMetadataProvider(),
                        new ModelStateDictionary())
                    {
                        Model = model
                    },
                    new TempDataDictionary(
                        context.HttpContext,
                        _tempDataProvider),
                    output,
                    new HtmlHelperOptions());
                view.RenderAsync(viewContext).GetAwaiter().GetResult();
                return output.ToString();
            }
        }
    }
