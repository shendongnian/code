    public class Base{}    
    public class Child : Base{}
    public class ChildOfChild : Child{}
    public class Another{}
    
    //...
    
    bool b1 = typeof(Child).IsSubclassOf(typeof(Base)); //true
    bool b2 = typeof(ChildOfChild).IsSubclassOf(typeof(Base)); //true
    bool b3 = typeof(Another).IsSubclassOf(typeof(Base)); //false
