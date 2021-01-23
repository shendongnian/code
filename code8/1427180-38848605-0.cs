    public abstract class BaseClass
    {
        // your base class implementation
    }
    public abstract class NamedBaseClass : BaseClass, IName
    {
        public string Name { get; set;}
        public override string ToString()
        {
            return Name;
        }
    }
