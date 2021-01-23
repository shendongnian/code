    using (var bus = RabbitHutch.CreateBus("host=localhost", serviceRegister => serviceRegister.Register<IConsumerErrorStrategy, DeadLetterStrategy>()))
    {
    	var deadExchange = bus.Advanced.ExchangeDeclare("exchange.text.dead", ExchangeType.Direct);
    	var textExchange = bus.Advanced.ExchangeDeclare("exchange.text", ExchangeType.Direct);
    	var queue = bus.Advanced.QueueDeclare("queue.text", deadLetterExchange: deadExchange.Name);
    	bus.Advanced.Bind(deadExchange, queue, "");
    	bus.Advanced.Bind(pippoExchange, queue, "");
    
    	bus.Advanced.Consume<TextMessage>(queue, (message, info) => HandleTextMessage(message, info));
    }
