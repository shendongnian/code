    public abstract class BaseClass
    {
        public abstract string TableName {get;}
    }
    
    public class DerivedClass : BaseClass
    {
       public override string TableName {get {return "Derived";} }
    }
