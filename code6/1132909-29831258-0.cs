    public abstract class MyClass
    {
        public event EventHandler MyEvent;
    
        protected virtual void OnMyEvent(EventArgs e)
        {
            if (this.MyEvent != null)
            {
                this.MyEvent(this, e);
            }
        }
    }
