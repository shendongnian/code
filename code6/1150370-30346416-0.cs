     public sealed class Foo<T> : IDisposable
        where T : IDisposable, new()
    {
       private readOnly object key;
       
        public Foo(){
          key = new Object();
          this.Bar = new T();
        }
    
        public T Bar
        {
            get { return _bar; }
            private set { 
            lock(key){
               _bar = value;
            }
          }
        }
    
        public void Reset()
        {
            var oldBar = _bar;
            lock(key)
            {
                this.Bar = new T();
            }
        }
    
        public void Dispose()
        {
            this.Bar = null;
        }
    
        private T _bar;
    }
