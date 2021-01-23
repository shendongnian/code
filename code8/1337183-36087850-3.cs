    public class Foo : Entity<Foo>, IFoo
    {
        public override void Interact(Foo entity)
        {
            // do something with entity...
        }
    
        public void DoFoo()
        {
           // Do foo stuff here..
        }
    }
