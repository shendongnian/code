    public class SecondClassWithGeneric<U, T> 
             where U : ClassWithGeneric<T>   
    {
        public T getNestedObject()
        {
            //How do I get the type of object T?
        }
    }
