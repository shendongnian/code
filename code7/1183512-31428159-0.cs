    public Message Call(Message message)
    {
       ...
       var props = _channel.CreateBasicProperties();
       props.DeliveryMode = 1; //you might want to do this in your RPC-Server as well
       ...
    }
