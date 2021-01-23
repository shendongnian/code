    public interface IViewHelper
    {
        string SerializeView(ControllerContext context, ViewDataDictionary viewData, TempDataDictionary tempData,
            string viewName, object model);
    }    
    public class ViewHelper : IViewHelper
    {
        private readonly ViewEngineCollection _viewEngines = ViewEngines.Engines;
        public string SerializeView(ControllerContext context, ViewDataDictionary viewData, TempDataDictionary tempData, string viewName, object model)
        {
            viewData.Model = model;
            using (var sw = new StringWriter())
            {
                // keep getting null reference errors on this line when I write my tests .
                var viewResult = _viewEngines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, tempData, sw);
                // render the view into the stringwriter class
                viewResult.View.Render(viewContext, sw);
                // output the rendered string
                return sw.GetStringBuilder().ToString();
            }
        }
    }
