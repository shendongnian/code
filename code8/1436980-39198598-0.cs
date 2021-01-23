    [assembly: PostApplicationStartMethod(typeof(SomeNameSpace.StartUp), "Start")]
    namespace SomeNameSpace
    {
    public static class StartUp
    {
        public static void Start()
        {
            
            MvcHandler.DisableMvcResponseHeader = true;
            RouteConfig.RegisterRoutes(RouteTable.Routes);
         }
     }
    }
