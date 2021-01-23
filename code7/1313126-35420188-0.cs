            public async Task StartConsuming(IMessageBusConsumer consumer, MessageBusConsumerName fullConsumerName, CancellationToken cancellationToken)
            {
                var queueName = GetQueueName(consumer.MessageBusConsumerEnum);
    
                using (var model = _rabbitConnection.CreateModel())
                {
                    // Configure the Quality of service for the model. Below is how what each setting means.
                    // BasicQos(0="Don't send me a new message until I’ve finished",  _fetchSize = "Send me N messages at a time", false ="Apply to this Model only")
                    model.BasicQos(0, consumer.FetchCount.Value, false);
                    var queueingConsumer = new QueueingBasicConsumer(model);
    
                    model.BasicConsume(queueName, false, fullConsumerName, queueingConsumer);
    
    
                    var queueEmpty = new BasicDeliverEventArgs(); //This is what gets returned if nothing in the queue is found.
    
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        var deliverEventArgs = queueingConsumer.Queue.DequeueNoWait(queueEmpty);
                        if (deliverEventArgs == queueEmpty)
                        {
                            // This 100ms wait allows the processor to go do other work.
                            // No sense in going back to an empty queue immediately. 
                            // CancellationToken intentionally not used!
                            // ReSharper disable once MethodSupportsCancellation
                            await Task.Delay(100);  
                            continue;
                        }
                        //DO YOUR WORK HERE!
                      }
    }
