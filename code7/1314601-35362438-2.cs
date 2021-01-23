    public interface IMessageHandler
    {
        void SendMessage(string message);
    }
    
    public class WindowsFormsMessageHandler : IMessageHandler
    {
        public void SendMessage(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
    }
    
    public class OuterClass
    {
        private IMessageHandler _handler;
    
        public OuterClass(IMessageHandler handler)
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
