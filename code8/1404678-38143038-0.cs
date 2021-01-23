    public static class InjectQueryStringMiddleware
    {
        public static void InjectQueryString(IOwinContext context)
        {
            if (context.Environment.ContainsKey("owin.RequestQueryString"))
            {
                var existingQs = context.Environment["owin.RequestQueryString"];
                var parser = new UrlParser(existingQs.ToString());
                parser[Constants.AuthorizeRequest.AcrValues] = newAcrValues;
                context.Environment.Remove("owin.RequestQueryString");
                context.Environment["owin.RequestQueryString"] = parser.ToString();
            }
        }
        public static void UseInjectQueryString(this IAppBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // some code here
                InjectQueryString(context);
            }
        }
    }
