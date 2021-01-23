    public class A 
    {
    }
    
    public class B : A
    {
    }
    
    A a = new B();
    
    // some code
    
    B b = (B)a; // it is possible. Behind the scenes, variable a is of B type.
