    public void ProvideFault(Exception error, MessageVersion version, ref Message fault) 
    {
        var myException = error as MyException;
        if (myException == null)
        {
            return;           
        }
    
        var err = new FaultException<Foo>(new Foo
            {
                MessageID = myException.MsgId
            }, "Server error");
        var msgFault = err.CreateMessageFault();
        fault = Message.CreateMessage(
            version,
            msgFault,
            null);
    } 
