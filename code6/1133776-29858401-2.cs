    class Base
    {
        public void Write()
        {
            SomeWriteMethod(Name());
        }
    
        public virtual void Name()
        {
            return "Base";
        }
    }
    
    class Derived : Base
    {
        public override void Name()
        {
            return "Derived";
        }
    }
