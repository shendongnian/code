    public abstract class BaseClass<TIdentifier>
    {
        public virtual object Me {get {return this;} }
    }
    
    public class A : BaseClass<TIdentifier>
    {
        public int X
        {
            get {return 1;}
        }
    }
    
    public class B : BaseClass<TIdentifier>
    {
        
    }
    
    public class controller{
        public void SomeMethod(){
            var a = new A();
            var b = new B();
    
            var aObject = a.Me; 
            var aObjectCasted = (A)aObject;
    
            // the environment cannot determine the correct type for aObject
            // without compiling and running. At this time in the editor,
            // this will be recognized as a type object. It will not
            // understand aObject.X and will not compile
            Console.WriteLine(aObject.X); 
    
            // During run-time, this will work. aObject will be defined as type A
            Console.WriteLine(aObject.GetType().GetProperty("X").GetValue(aObject));
    
            // this will output A for the type
            Console.WriteLine(aObject.GetType());
       }
    }
