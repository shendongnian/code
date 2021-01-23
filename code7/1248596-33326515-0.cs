    class ViewModel1
    {
        private void sendMessage()
        {
            Messenger.Default.Send<InputStringMessage>(msg);
        }
    }
.
    class ViewModel2
    {
        public ViewModel2()
        {
             Messenger.Default.Register<InputStringMessage>(this, (action) => ReceiveInputMessage(action));
        }
        protected void ReceiveInputMessage(InputStringMessagemessage)
        {
            ...
        }
