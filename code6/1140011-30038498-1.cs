    public delegate MessageBoxResult RequestConfirmationHandler(object sender, ConfirmationInteractionEventArgs e);
     
    public interface IConfirmationInteraction
    {
        event RequestConfirmationHandler RequestConfirmation;
        MessageBoxResult Confirm();
    }
    public class ConfirmationInteraction : IConfirmationInteraction
    {
        #region Events
        public event RequestConfirmationHandler RequestConfirmation;
        #endregion
 
        #region Members
        object _sender = null;
        ConfirmationInteractionEventArgs _e = null;
        #endregion
 
        public ConfirmationInteraction(object sender, ConfirmationInteractionEventArgs e)
        {
            _sender = sender;
            _e = e;
        }
 
        public MessageBoxResult Confirm()
        {
            return RequestConfirmation(_sender, _e);
        }
 
        public MessageBoxResult Confirm(string message, string caption)
        {
            _e.Message = message;
            _e.Caption = caption;
            return RequestConfirmation(_sender, _e);
        }
    }
}
   
    public class ConfirmationInteractionEventArgs : EventArgs
        {
            public ConfirmationInteractionEventArgs() { }
     
            public ConfirmationInteractionEventArgs(string message, string caption, object parameter = null)
            {
                Message = message;
                Caption = caption;
                Parameter = parameter;
            }
     
            public string Message { get; set; }
            public string Caption { get; set; }
            public object Parameter { get; set; }
        }
