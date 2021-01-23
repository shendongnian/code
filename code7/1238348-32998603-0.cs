    public abstract class Base
    {
        public void TemplateMethod()
        {
            //do sth
            OtherMethod();
            //do sth more
        }
        protected abstract void OtherMethod();
    }
    public class Child : Base
    {
        protected override void OtherMethod()
        {
            //provide implementation
        }
    }
