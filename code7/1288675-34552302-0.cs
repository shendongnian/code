    class Foo
    {
        private readonly string _value;
    
        public Foo()
        {
            Bar(ref _value);
        }
    	
    	public void Baz()
    	{
    		Bar(ref _value);
    	}
    
        private void Bar(ref string value)
        {
            value = "hello world";
        }
    
        public string Value
        {
            get { return _value; }
        }
    }
