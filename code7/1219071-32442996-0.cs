    public delegate void Handler<T> ( T i );
    public class Foo
    {
        public Handler<int> fooh;
        public void Set(int i) {
            if (fooh != null) {
                fooh(i);
            }
        }   
    }
    public class ShortTermMemory<T>
    {
        Handler<T> arg = null;
        public ShortTermMemory (ref Handler<T> arg ) {
            arg += set;
            this.arg = arg;
        }
        ~ShortTermMemory() {
            if (arg != null) {
                arg -= set;
            }
        }
        public T Remember { get; set; }
        protected void set(T t) {
            Remember = t;
        }
    }
    
    var foo = new Foo();
    var intmemory1 = new ShortTermMemory<int>(ref foo.fooh);
    var intmemory2 = new ShortTermMemory<int>(ref foo.fooh);
    foo.Set(10);
