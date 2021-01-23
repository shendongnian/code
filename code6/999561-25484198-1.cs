    public class WithVirtualPropAttribute : Attribute
    {
        public virtual String Prop {get; set;}
    }
    
    public class DerivedFromWithVirtualPropAttribute : WithVirtualPropAttribute 
    {
        // Compiles ok
        public virtual String Prop {get{return "0"} set{}}
    }
    
    public class WithoutVirtualPropAttribute : Attribute
    {
        public virtual String Prop {get; set;}
    }
    
    public class DerivedFromWithoutVirtualPropAttribute : WithoutVirtualPropAttribute 
    {
        // Compilation error !!!!!!!!!!!!!!!!!!!!!!!!!!
        public virtual String Prop {get{return "0"} set{}}
    }
