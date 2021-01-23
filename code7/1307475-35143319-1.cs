     static MyClass threadSafeClass = new MyClass();
     void ThreadOne()
     {
        while (true) 
        {
            threadSafeClass.UpdateValue(MyEnum.Second);
            DoSomething();
        }
     }
     void ThreadTwo()
     {
        while (true)
        {
           threadSafeClass.UpdateValue(MyEnum.First);
           DoSomething();
        }
     }
