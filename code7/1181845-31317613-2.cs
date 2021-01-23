    class MyClass 
    {
        private int setting;
      
        public MyClass(ref int setting) 
        {
           SomeOtherClass instance = new SomeOtherClass(s => setting = s);
        }
    }
        
    class SomeOtherClass
    {
        Action<int> changeValue;
        public SomeOtherClass(Action<int> method) { changeValue = method; }    
       // invoke it and pass new value where you need it :
       // void SomeWhereInCode() { changeValue(100); }
    }
