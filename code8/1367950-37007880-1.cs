    public abstract class AsynchronousClientBase
    {
        public abstract object GetAutomationObject();
        public virtual object GetFoo()
        {
            return null;
        }
    }
    public class AsynchronousClient : AsynchronousClientBase
    {
        public override object GetAutomationObject()
        {
            return this;
        }
        public override object GetFoo()
        {
            return new Foo();
        }
    }
