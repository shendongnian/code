    public class MyHelper : IMyHelper
    {
        private Func<IService> _serviceBuilderFunc;
        public MyHelper(Func<IService> serviceBuilderFunc)
        {
            _serviceBuilderFunc = serviceBuilderFunc;
        }
    
        public void SomeMethod()
        {
            var svc = _serviceBuilderFunc();
            svc.RunSomething();
        }
    }
