    public sealed class MyOtherClass : MyClass
    {
        public int MyState { get; private set; }
        public void DoMyEvent(bool doSomething)
        {
            // Custom logic that does whatever you need to do
            if (doSomething)
            {
                OnMyEvent(EventArgs.Empty);
            }
        }
        protected override void OnMyEvent(EventArgs e)
        {
            // Do some custom logic, then call the base method
            this.MyState++;
            base.OnMyEvent(e);
        }
    }
