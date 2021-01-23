    interface IDo {
       void DoSomething();
    }
    
    class MyFile : File, IDo {
       void DoSomething() {
           // blah blah
       }
    }
    
    class MyJObject : JObject, IDo {
       void DoSomething() {
           // blah blah
       }
    }
    
    public static void MyMethod<T1, T2>(T1 one, T2 two)
        where T1 : IDo
        where T2 : IDo
    {
       one.DoSomething();
       two.DoSomething();
    }
