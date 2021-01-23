    public class MyRegistry : UnityRegistry
    {
        public MyRegistry()
        {
            Register<IMyService, MyService>();
            Register<IObserver, Ob1>().WithName("observer1");
            Register<IObserver, Ob2>().WithName("observer2");
        }
    }
