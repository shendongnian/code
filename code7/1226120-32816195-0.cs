    static void Main(string[] args)
    {
        //create an event
        MessageQueue msmq = new MessageQueue("queuename");
        //subscribe to the event
        msmq.ReceiveCompleted += msmq_ReceiveCompleted;
        //start listening
        msmq.BeginReceive();
    }
    
    //this will be fired everytime a message is received
    static void msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
    {
        //get the MessageQueue that we used 
        MessageQueue msmq = sender as MessageQueue;
        
        //read the message
        //and process it
        Message msg = msmq.EndReceive(e.AsyncResult);
    
        //because this method is only fired once everytime
        //a message is sent to the queue
        //we have to start listening again            
        msmq.BeginReceive();
    }
