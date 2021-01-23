    public class UsersService : Service
    {
        public IAutoQuery AutoQuery { get; set; }
    
        public object Any(Users request)
        {
            Dictionary<string, string> args = Request.GetRequestParams();
            args.Remove("OrganizationId");// E.g remove conflicted fields
    
            var q = AutoQuery.CreateQuery(request, args);
            return AutoQuery.Execute(request, q);
        }
    }
