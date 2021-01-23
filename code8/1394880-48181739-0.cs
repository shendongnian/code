    public class BaseClass
    {
        public virtual string Prop {get; set;}
    }
     
    public class Derived: BaseClass
    {
        public string Comp1 {get; set;}
        public string Comp2 {get; set;}
        public override string Prop {get => Comp1 + Comp2; set {}}
    }
