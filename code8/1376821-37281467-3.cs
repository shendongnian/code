      public class MyClass {
        ... 
        public MyClass(IMyMethod1 method1, IMyMethod2 method2) {
          if ((null == method1) && (null == method2))
            throw new ArgumentNullException("method1", 
              "You should provide either method1 or method2");
    
          m_Method1 = method1;
          m_Method2 = method2;
        }
    
        ...
    
        public void DoSomething() {
          ... 
          if (m_Method1 != null)
            m_Method1.MyMethod1(); 
          else if (m_Method2 != null)
            m_Method2.MyMethod2(); 
          ...
        }
      }
