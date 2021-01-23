    public interface IMessagetHandler
    {
        void SendMessage(string message);
    }
    
    public class WindowsFormsMessageHandler : IMessagetHandler
    {
        public void SendMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
    }
    
    public class OuterClass
    {
        private IMessagetHandler _handler;
    
        public OuterClass(IMessagetHandler handler)
        {
            if (handler == null)
                throw new ArgumentNullException("handler");
    
            _handler = handler;
        }
    
        public void DoSomething()
        {
            _handler.SendMessage("Hello");
        }    
    }
...
    var testClassInWindowsForms = new OuterClass(new WindowsFormsMessageHandler());
    test.DoSomething();
