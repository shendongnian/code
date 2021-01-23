    public class First { }
    public class Second : First { }
    public delegate First SampleDelegate(Second a);
    public delegate R SampleGenericDelegate<A, R>(A a);
    
    // Matching signature. 
    public static First ASecondRFirst(Second first)
    { return new First(); }
    
    // The return type is more derived. 
    public static Second ASecondRSecond(Second second)
    { return new Second(); }
    
    // The argument type is less derived. 
    public static First AFirstRFirst(First first)
    { return new First(); }
    
    // The return type is more derived  
    // and the argument type is less derived. 
    public static Second AFirstRSecond(First first)
    { return new Second(); }
    
    // Assigning a method with a matching signature  
    // to a non-generic delegate. No conversion is necessary.
    SampleDelegate dNonGeneric = ASecondRFirst;
    // Assigning a method with a more derived return type  
    // and less derived argument type to a non-generic delegate. 
    // The implicit conversion is used.
    SampleDelegate dNonGenericConversion = AFirstRSecond;
    
    // Assigning a method with a matching signature to a generic delegate. 
    // No conversion is necessary.
    SampleGenericDelegate<Second, First> dGeneric = ASecondRFirst;
    // Assigning a method with a more derived return type  
    // and less derived argument type to a generic delegate. 
    // The implicit conversion is used.
    SampleGenericDelegate<Second, First> dGenericConversion = AFirstRSecond;
