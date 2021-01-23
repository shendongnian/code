    public class CustomViewEngine : RazorViewEngine
    {
        private List<string> _plugins = new List<string>();
        public CustomViewEngine(List<string> pluginFolders)
        {
            _plugins = pluginFolders;
            ViewLocationFormats = GetViewLocations();
            MasterLocationFormats = GetMasterLocations();
            PartialViewLocationFormats = GetViewLocations();
        }
        public string[] GetViewLocations()
        {
            var views = new List<string>();
            views.Add("~/Views/{1}/{0}.cshtml");
            foreach (string p in _plugins)
            {
                views.Add("~/Modules/" + p + "/Views/{1}/{0}.cshtml");
            }
            return views.ToArray();
        }
        public string[] GetMasterLocations()
        {
            var masterPages = new List<string>();
            masterPages.Add("~/Views/Shared/{0}.cshtml");
            foreach (string p in _plugins)
            {
                masterPages.Add("~/Modules/" + p + "/Views/Shared/{0}.cshtml");
            }
            return masterPages.ToArray();
        }
    }
