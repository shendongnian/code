    public abstract class TestBase:ITest
    {
        
        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event StatusChangedEventHandler StatusChanged;
        protected virtual void OnStatusChanged(StatusChangedEventArgs e)
        {
            if (StatusChanged != null)
                StatusChanged(this, e);
        }
        protected virtual void ReportProgress (int percentage, string step)
        {
            OnStatusChanged(new StatusChangedEventArgs()
            {
                Percentage = percentage,
                Step = step
            });
        }
        public abstract void Execute();
    }
