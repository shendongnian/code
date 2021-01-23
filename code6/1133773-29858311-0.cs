    class Base
    {
        public void Write()
        {
         if (this is Derived)
          {
             this.Name();//calls Name Method of Base class i.e. prints Base
            ((Derived)this).Name();//calls Derived Method i.e prints Derived 
          }
         else
          {
            this.Name();
          }
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
