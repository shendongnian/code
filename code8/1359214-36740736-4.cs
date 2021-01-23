        public interface IServiceFactory 
        {
            MyBusinessManager GetInstance();
        }
        public class ServiceFactory : IServiceFactory
        {
            public MyBusinessManager GetInstance()
            {
                return MyBusinessManager.GetInstance();
            }
        }
        IServiceFactory factory = new ServiceFactory();
        public bool MyServiceMethod(int serviceParam)
        {
            MyBusinessManager dvqBusinessManager = factory.GetInstance();
            dvqBusinessManager.MyBusinessManagerMethod(serviceParam);
        }
