       public abstract class SomeBaseClass
        {
            public event EventHandler SomeEvent;
            protected Action<object, EventArgs> SomeEventInvoker;
            public SomeBaseClass()
            {
                SomeEventInvoker = new Action<object, EventArgs>((sender, args) => 
                 { if (SomeEvent != null) SomeEvent(sender, args); });
            }
        }
       public class SomeClass : SomeBaseClass
        {
            public SomeClass()
            {
                DoSomething();
            }
            public void DoSomething()
            {                
                SomeEventInvoker(this, new EventArgs());
            }
        }
