    class MsmqListener
    {
       public void StartListening(string queuePath)
        {
            MessageQueue msQueue = new MessageQueue(@".\private$\" + queuePath);
            msQueue.ReceiveCompleted += QueueMessageReceived;
            msQueue.BeginReceive();
            // you can do averything here, its async
        }
        private void QueueMessageReceived(object source, ReceiveCompletedEventArgs args)
        {
            MessageQueue msQueue = (MessageQueue)source;
            //once a message is received, stop receiving
            Message msMessage = null;
            msMessage = msQueue.EndReceive(args.AsyncResult);
            //do something with the message
            //...
           
            //begin receiving again
            msQueue.BeginReceive();
        }
    }
