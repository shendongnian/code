    public class BaseClass
    {
    }
    
    public class FinalClass : BaseClass
    {
    }
    
    public class A
    {
        private BaseClass baseProp;
        public virtual BaseClass BaseClassProperty {get { return baseProp; } }
    }
    
    public class B : A
    {
        private FinalClass finalProp;
        public override BaseClass BaseClassProperty {get { return finalProp; } }
    }
