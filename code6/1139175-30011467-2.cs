    public class MyClass
    {
        public virtual string Name { get { return "I am base" } }
    }
    
    public class MyInheritedClass : MyClass
    {
        public override string Name { get { return "I am derived" } };
    }
 
