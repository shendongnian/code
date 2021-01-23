    public class MvcApplication : System.Web.HttpApplication  
    {  
       protected void Application_Start()  
       {  
          ViewEngines.Engines.Clear();  
          ViewEngines.Engines.Add(new RazorViewEngine()  
          {  
             PartialViewLocationFormats = new[]  
             {  
                "~/View/Shared/EditorTemplates/{0}.cshtml",  
                "~/Areas/Admin/View/Shared/EditorTemplates/{0}.cshtml"  
             }  
          });  
       }  
    }  
