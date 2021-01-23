    public abstract class Base
    {
        // Note: this is *not* virtual.
        public void SomeMethod()
        {
            // Do some work here
            SomeMethodImpl();
            // Do some work here
        }
        protected abstract void SomeMethodImpl();
    }
