        public event EventHandler<MessageRecievedEventArgs> MessageRecieved;
        protected virtual void OnMessageReceived(object sender, MessageRecievedEventArgs args)
        {
            var handle = MessageRecieved;
            if (handle == null)
                return;
            if(MainUIThread  != null)
            {
                MainUIThread.Post(d => handle(sender, args), this);
            }
            else
            {
                handle(sender, args);
            }
        }
