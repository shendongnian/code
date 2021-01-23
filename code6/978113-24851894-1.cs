    public class foo<T>
    {
        public T x;
        public foo () {  }
    	public foo(T x) { this.x = x; }
    }
    
    public class bar : foo <SomeType>
    {
        public bar()
    		: base(new SomeType())
        {
        }
    }
