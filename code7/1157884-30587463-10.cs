    public class PostRouteAttribute : VerbRouteAttribute
    {
        public PostRouteAttribute(string template) : base(template, "POST")
        {
        }
    }
    public class DeleteRouteAttribute : VerbRouteAttribute
    {
        public DeleteRouteAttribute(string template) : base(template, "DELETE")
        {
        }
    }
