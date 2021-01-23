     public abstract class AbstractClass
     {
         public static void Foo<T>(T item)
         {
             Console.WriteLine(typeof(T).Name + ": " + item);
         }
     }
