    public class Foo
    {
        public void Update()
        {
            this.OnUpdating();
            this.PerformUpdate();
            this.OnUpdated();
        }
        public virtual void PerformUpdate()
        {
            // Leave this empty. Let the subclass override it and do their own thing. Your parent code will still get called when Update() is called.
        }
        public void OnUpdating()
        {
            // Invoke code that you want to guarantee is always executed PRIOR the overridden PerformUpdate() method is finished.
        }
        public void OnUpdated()
        {
            // Invoke code that you want to guarantee is always executed AFTER the overridden PerformUpdate() method is finished.
        }
    }
    public class Bar : Foo
    {
        public override void PerformUpdate()
        {
            // Do custom stuff, don't have to call base.PerformUpdate() because it already does it's code in OnUpdating() and OnUpdated().
        }
    }
