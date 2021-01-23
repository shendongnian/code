       public class A : A<object>
       {
           public static A<T> GetInstance<T>() => new A<T>();
           public new static A GetInstance() => new A();
       }
        
       public class A<T>
       {
           public static A<T> GetInstance() => new A<T>();
       }
