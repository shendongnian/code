    public event EventHandler<string> MessageHasSent;
    public void SendMessage(string message)
    {
        EventHandler<string> ms =  MessageHasSent;
        if (ms!= null)
        {
             ms(this,message);
        }
    }
