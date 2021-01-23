    public class Foo
    {
        public virtual void Update()
        {
            // Do stuff
        }
    }
    public class Bar : Foo
    {
        public override void Update()
        {
            // Replaces the parents implementation of the Update method due to not calling base.Load();
        }
    }
