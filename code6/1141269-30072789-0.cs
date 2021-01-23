      public abstract class MyClass {
        ...
        protected MyClass() {
        }
    
        public static MyClass Create() {
          if (...)
            return new MyClassOne();
          else if (...)   
            return new MyClassTwo();
          ...
        } 
    
        public abctract void DoSomething();
      }
    
      ...
    
      MyClass my = MyClass.Create();
      // I have no need to choose which concrete class (MyClassOne, MyClassOne etc.) 
      // will do something for me 
      my.DoSomething(); 
