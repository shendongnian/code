    public class Foo : Entity, IFoo
    {
        public void Interact(IFoo entity)
        {
            // do something with entity...
        }
    
        public void DoFoo()
        {
           // Do foo stuff here..
        }
    }
    
    public class Bar : Entity, IBar
    {
        public void Interact(IBar entity)
        {
            // do something with obj..
        }
    
        public void DoBar()
        {
           // Do bar stuff here..
        }
    }
