    public class BaseViewModel
    {
        public event EventHandler ClosingRequest;
    
        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }
    }
