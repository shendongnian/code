    public sealed class MyOtherClass : MyClass
    {
        public void DoMyEvent(bool doSomething)
        {
            // Custom logic that does whatever you need to do
            if (doSomething)
            {
                OnMyEvent(EventArgs.Empty);
            }
        }
    }
