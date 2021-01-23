      public class MyCustomViewEngine : RazorViewEngine
    {
       
        public MyCustomViewEngine()
        {         
            
            ViewLocationFormats = new string[] {
                "~/MyViews/{1}/{0}.cshtml",
                "~/MyViews/Shared/{0}.cshtml" };
            MasterLocationFormats = new string[] {
                "~/MyViews/{1}/{0}.cshtml",
                "~/MyViews/Shared/{0}.cshtml"};
            PartialViewLocationFormats = new string[] {
                "~/MyViews/{1}/{0}.cshtml",
                 "~/MyViews/Shared/{0}.cshtml"};
            FileExtensions = new string[] { "cshtml" };
        }
    }
