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
        public void NotifyNewComment(int id)
        {
            var email = new NotificationEmail
            {
                To = "yourmail@example.com",
                Comment = comment.Text
            };
    
            email.Send();
        }
        // etc.
    }
