    public class MyModule : NancyModule
    {
        public MyModule()
        {
            Get["/", true] = async(x, ct) =>
            {
                IDictionary<string, object> environment = Context.GetOwinEnvironment();
                IOwinContext context = (IOwinContext)environment["Context"]; // The same "Context" as added in the Middleware
            }
        }
