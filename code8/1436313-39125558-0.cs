    bool noAck = false;
    BasicGetResult result = channel.BasicGet(queueName, noAck);
    if (result == null) {
        // No message available at this time.
    } else {
        IBasicProperties props = result.BasicProperties;
        byte[] body = result.Body;
        ...
    Since noAck = false above, you must also call IModel.BasicAck to acknowledge that you have successfully received and processed the message:
        ...
        // acknowledge receipt of the message
        channel.BasicAck(result.DeliveryTag, false);
    }
 
