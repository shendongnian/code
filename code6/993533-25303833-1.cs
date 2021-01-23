    class MyClass
    {
        IUtility _util;
    
        public MyClass(IUtility util)
        {
            _util = util;
        }
    
        public Task OnStep()
        {
           this.Property = _util.Method();
        }
    }
    
    public TestMethod()
    {
        IUtility fakeUtil = Mock.Of<IUtility>();
    
        MyClass x = new MyClass(fakeUtil);
    
        
    }
