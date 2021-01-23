    interface ICov<out T>
    {
        List<T> ListOfT { get; set; }
        // ^^^ compiler doesn't like this.
    }
    public class BaseClass { }
    public class InheritedClass: BaseClass { } 
    public class MyCov<T> : ICov<T> {
        public List<T> ListOfT { get; set; } = new List<T>();
    }
