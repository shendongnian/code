    public class Foo
    {
        public void Update()
        {
            this.OnUpdating();
            this.PerformUpdate();
            this.OnUpdated();
        }
        // Child class is required to implement this method. Only downside is you will no longer be able to instance the base class. If that is acceptable, then this is really the preferred way IMO for what you are wanting to do.
        public abstract void PerformUpdate();
        public void OnUpdating()
        {
            // Invoke code that you want to guarantee is always executed PRIOR the overridden PerformUpdate() method is finished.
        }
        public void OnUpdated()
        {
            // Invoke code that you want to guarantee is always executed AFTER the overridden PerformUpdate() method is finished.
        }
    }
