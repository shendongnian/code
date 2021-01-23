    class Test<T> {
      private Test(string x) {
      }  
    
      public static Test<T> OpTest(T t) {
        return new Test<T>("test string") {
          Value1 = t,
        }
      }
    
      public T Value1 {get;set;}
      public string X {get;set;}
    }
    
    class TestExtra<T, U> : Test<T> {
      private TestExtra(string x) : base(x) {
      }  
    
      public static TestExtra<T, U> OpTestExtra(T t, U u) {
        return new Test<T>("test string") {
          Value1 = t,
          Value2 = u
        }
      }
    
      public U Value2 {get;set;}
    }
    
    
    var result = Test<SomeClass>.OpTest(instanceOfSomeClass);
    var anotherResult = TestExtra<SomeClass, SomeOtherClass>
        .OpTestExtra(instanceOfSomeClass, instanceOfSomeOtherClass);
