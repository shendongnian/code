    public class foo<SomeType>
    {
        public SomeType x;
        public foo () {  }
    	public foo(SomeType x) { this.x = x; }
    }
    
    public class bar : foo <SomeType>
    {
        public bar()
    		: base(new SomeType())
        {
        }
    }
