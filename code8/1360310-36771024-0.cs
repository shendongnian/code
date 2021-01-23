    public class A<T>
    {
        public T { get; set;}
        public A() {};
    }
    public class B: A<TimeZone>
    {
        public B() {};
        public void Whatever() 
        {
            T.UtcOffset = 47;
        }
    }
    public class C: A<string>
    {
         public C() {};
         public void Whatever() 
         {
              T = "47";
         }
    }
