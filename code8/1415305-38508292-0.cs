    interface ICov<out T> {}
    public class BaseClass { }
    public class InheritedClass: BaseClass { } 
 
    ICov<BaseClass> x = new MyCov<InheritedClass>();
