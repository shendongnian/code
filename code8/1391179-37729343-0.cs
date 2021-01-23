    class Factory 
    {
        public event EventHandler<MessagereceivedEventArgs> MessageReceived;
        void ReceiveMessage(string Message)
        {
            // Do something with the Message
            // Then let your subscribers know that the message has been processed:
            if (MessageReceived != null)
            {
                var ea = new MessageReceivedEventArgs();
                ea.Message = Message;
                // Set ea properties as appropriate 
                MessageReceived(this, ea);
                // Check ea properties for change
                if (ea.Message != Message)
                {
                    // A subscriber has changed the message in the MessageReceivedEventArgs
                }
            }
        }
    }
