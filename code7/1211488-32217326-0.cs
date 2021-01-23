    class WrapperToImplementBoth : IImplementsBothMethods
    {
       private dynamic inner;
       public WrapperToImplementBoth(dynamic v)
       {
            inner = v;
       }
       // let dynamic handle calls, consider catching/logging exceptions  
       public void Method1() {inner.Method1()}; 
       public void Method2() {inner.Method2()};
    }
