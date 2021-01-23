    public class MyService : IMyService
    {
        public List<IMyServiceCallback> Callbacks { get; private set; }
        public MyService(){
            Callbacks = new List<IMyServiceCallback>();
        }
        public void Init()
        {
            Callbacks.Add(Callback);
        }
    // and so on
