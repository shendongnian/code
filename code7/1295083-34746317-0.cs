    public abstract class tObject<T> where T:tObject
    {
       public T[] someMethod(){;}
    }
    public class myClass : tObject<myClass>
    {
       public string Oth0 { get; set; }
       public string Oth1 { get; set; }
       public string Oth2 { get; set; }
    }
