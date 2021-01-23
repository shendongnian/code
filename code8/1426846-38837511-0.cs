    public class EmailService 
    {
        private string viewsPath;
        private ViewEngineCollection engines;
        public EmailService()
        {
            viewsPath = Path.GetFullPath(HostingEnvironment.MapPath(@"~/Views/Emails"));
            engines = new ViewEngineCollection();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));
        }
        // your methods
    }
