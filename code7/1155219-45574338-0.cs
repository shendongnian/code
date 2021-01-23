    public class AuthenticatedOnServerCacheAttribute : DonutOutputCacheAttribute
    {
        private OutputCacheLocation? originalLocation;
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            
            //NO CACHING this way
            if (ConfigurationManager.AppSettings["UseCache"] == "false")
            {
                originalLocation = originalLocation ?? Location;
                Location = OutputCacheLocation.None;
            }
            //Caching is on
            else
            {
                Location = originalLocation ?? Location;
            }
            base.OnResultExecuting(filterContext);
        }
    }
