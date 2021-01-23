    public class MyClass
    {
        public string name = "I am the Base";
        public virtual string Name { get { return this.name; } }
    }
    
    public class MyInheritedClass : MyClass
    {
        public new string name = "I inherit Base";
        public override string Name { get { return this.name } };
    }
