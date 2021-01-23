    public delegate void Handler<T> ( T i );
    public class Foo
    {
        public event Handler<int> Fooh;
        public void Set(int i) {
            if (Fooh != null) {
                Fooh(i);
            }
        }
    }
    public class ShortTermMemory<T>
    {
        object obj = null;
        string eventName;
        Handler<T> handler;
        public ShortTermMemory (object obj, string eventName) {
            this.obj = obj;
            this.eventName = eventName;
            this.handler = new Handler<T>(Set);
            Type type = obj.GetType();
            EventInfo info = type.GetEvent(eventName);
            info.AddEventHandler(obj, handler);
        }
        ~ShortTermMemory() {
            if (obj != null) {
                Type type = obj.GetType();
                EventInfo info = type.GetEvent(eventName);
                info.RemoveEventHandler(obj, handler);
            }
        }
        public T Remember { get; set; }
        public void Set(T t) {
            Remember = t;
        }
    }
    var foo = new Foo();
    var intmemory1 = new ShortTermMemory<int>(foo, "Fooh");
    var intmemory2 = new ShortTermMemory<int>(foo, "Fooh");
    foo.Set(10);
