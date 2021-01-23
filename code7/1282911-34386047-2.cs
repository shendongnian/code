    public class MyServiceProxy : IMyService
    {
        public int DoWork(string someParameter)
        {
            return ServiceLocator.Resolve<IMyService>().DoWork(someParameter);
        }
    }
