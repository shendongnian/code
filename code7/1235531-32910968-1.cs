    public class MyEventArgs 
    {
        public Action<dynamic> Callback { get; set; }
        public MyEventArgs(Action<dynamic> callback)
        {
            Callback = callback;
        }
    }
