    public class BaseClass
     {
        public bool SupportsA
        {
            get { return (this.GetType().GetMethod("A").DeclaringType == typeof(BaseClass)); }
        }
        public virtual void A()
        {
            // Null default implementation.
        }
    }
