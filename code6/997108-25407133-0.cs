    SampleGenericDelegate<First, Second> secdel = AFirstRSecond;
    secdel(new First()); //compilation error here.
    
    public class First { }
    public class Second : First { }
    public delegate R SampleGenericDelegate<A, R>(A a);
    public static Second AFirstRSecond(First first)
    { 
        return new Second(); 
    }    
