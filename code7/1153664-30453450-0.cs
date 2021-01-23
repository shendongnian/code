    public void BeforeSendReply(ref Message reply, object correlationState)
        {
                MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
                reply = buffer.CreateMessage();
                string message = buffer.CreateMessage();
                ...
