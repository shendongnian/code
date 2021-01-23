     public void SubscribeListner()
        {
            Subscription subscription = null;
            const string uploaderExchange = "myQueueExchange";
            string queueName = "myQueue";
            while (true)
            {
                try
                {
                    if (subscription == null)
                    {
                        try
                        {
                           //CONNECT Code
                            //try to open connection
                            connection = factory.CreateConnection();
                        }
                        catch (BrokerUnreachableException ex)
                        {
                            //You probably want to log the error and cancel after N tries, 
                            //otherwise start the loop over to try to connect again after a second or so.
                            //log.Error(ex);
                            continue;
                        }
                        
                        //crate chanel
                        channel = connection.CreateModel();
                        // This instructs the channel not to prefetch more than one message
                        channel.BasicQos(0, 1, false);
                        // Create a new, durable exchange
                        channel.ExchangeDeclare(uploaderExchange, ExchangeType.Direct, true, false, null);
                        // Create a new, durable queue
                        channel.QueueDeclare(queueName, true, false, false, null);
                        // Bind the queue to the exchange
                        channel.QueueBind(queueName, uploaderExchange, queueName);
                        //create subscription
                        subscription = new Subscription(channel, uploaderExchange, false);
                    }
                    BasicDeliverEventArgs eventArgs;
                    var gotMessage = subscription.Next(250, out eventArgs);//250 millisecond
                    if (gotMessage)
                    {
                        if (eventArgs == null)
                        {
                            //This means the connection is closed.
                            //DisposeAllConnectionObjects();
                            continue;//move to new iterate
                        }
                        //process message
                        subscription.Ack(); 
                        //channel.BasicAck(eventArgs.DeliveryTag, false);
                    }
                }
                catch (OperationInterruptedException ex)
                {
                    //log.Error(ex);
                    //DisposeAllConnectionObjects();
                }
                catch(Exception ex)
                {
                }
            }
        }
  
