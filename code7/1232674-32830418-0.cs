    public class IDParserMiddleware : OwinMiddleware
    {
        private ClientSettings Settings;
        public IDParserMiddleware(OwinMiddleware next, ClientSettings settings)
            : base(next)
        {
            Settings = settings;
        }
        public override Task Invoke(IOwinContext context)
        {
            string[] query = context.Request.QueryString.Value.Split('&');
            string id = null;
            foreach (string keyvalue in query)
            {
                if (keyvalue.StartsWith("id=", StringComparison.InvariantCultureIgnoreCase))
                {
                    id = keyvalue.Substring(3); // right after "id="
                    break;
                }
            }
            Settings.ID = Guid.Parse(id);
            return this.Next.Invoke(context);
        }
    }
