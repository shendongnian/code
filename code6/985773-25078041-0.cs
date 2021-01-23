    public class A<T>
        where T : C
    {
        public T mObj:
    }
    
    public class B : A<D> 
    {
    }
    
    public class C 
    {
        public int val1;
    }
    
    public class D : C 
    {
        public int val2;
    }
