    public event EventHandler<string> MessageHasSended ;
    public void SendMessage(string message)
    {
        EventHandler<string> ms =  MessageHasSended;
        if (ms!= null)
        {
             ms(this,message);
        }
    }
