    public abstract class SomeBaseClass
    {
        public event EventHandler SomeEvent;
        protected void RaiseSomeEvent(EventArgs e)
        {
            var eh = SomeEvent;
            if (eh != null)
                eh(this, e);
        }
    }
    
    public class SomeClass : SomeBaseClass
    {
        public void DoSomething()
        {
            //TODO
            RaiseSomeEvent(EventArgs.Empty);
        }
    }
