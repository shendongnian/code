    using System.Web.Mvc;
    
    public class ViewEngine : RazorViewEngine
    {
        public ViewEngine()
        {
                MasterLocationFormats = new[]
                {
                     // your layout cshtml files here
                };
    
                ViewLocationFormats = new[]
                {
                     // your view cshtml files here. {0} = action name, {1} = controller name
                     // example:
                     "~/Culture/{1}/{0}.cshtml"
                };
                PartialViewLocationFormats = ViewLocationFormats;
    
                FileExtensions = new[]
                {
                    "cshtml"
                };
        }
    }
