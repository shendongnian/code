    public class HandlerFactory : IHttpHandlerFactory
    {
        private readonly UnityContainer m_Container;
        public HandlerFactory()
        {
            m_Container = new UnityContainer();
            m_Container.RegisterType<IService, Service>();
        }
        public IHttpHandler GetHandler(HttpContext context, string request_type, string url, string path_translated)
        {
            if (url.EndsWith(".ext1"))
                return m_Container.Resolve<MyHandler>();
            //Here for other cases, we can resolve other handlers
            return null;
        }
        public void ReleaseHandler(IHttpHandler handler)
        {
            //Here we should use the container to release the handler. However, unity seems to be missing this feature
        }
    }
