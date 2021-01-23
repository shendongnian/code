    public class MyClassEventArgs : Event Args { }
    
    public interface IMyInterface
    {
        event EventHandler<MyClassEventArgs> MyClassEvent;
    }
    
    public class Implementation : IMyInterface
    {
        public EventHandler<MyClassEventArgs> MyClassEvent;
    
        public void OnSomethingHappened()
        {
            MyClassEvent?.Invoke(this, new MyClassEventArgs());
        }
    }
