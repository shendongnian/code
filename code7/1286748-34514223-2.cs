    public class MyDisposable : IDisposable
    {
        private string message_;
 
        public MyDisposable(string message)
        {
            this.message_ = message;
        }
 
        #region IDisposable Members
 
        public void Dispose()
        {
            MessageBox.Show(this.message_);
        }
 
        #endregion
    }
 
