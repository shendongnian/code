    public abstract class SomeBaseClass
    {
        public virtual event EventHandler SomeEvent;
    
        protected virtual void HandleSomeEvent()
        {
            var ev = SomeEvent; // Localize event field used
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }
    }
    
    public class SomeClass : SomeBaseClass
    {
        public override event EventHandler SomeEvent
        {
            add { base.SomeEvent += value; }
            remove { base.SomeEvent -= value; }
        }
    
        protected override void HandleSomeEvent()
        {
            base.HandleSomeEvent();
            // ... My own code here
        }
    }
