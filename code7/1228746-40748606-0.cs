            using (IConnection conn = factory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                channel.ExchangeDeclare(exchange, ExchangeType.Direct, durable: true);
                channel.QueueDeclare(queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                channel.QueueBind(queue, exchange, routingKey, null);
                var props = channel.CreateBasicProperties();
                props.DeliveryMode = 2;
                channel.BasicPublish(exchange, routingKey, props, Encoding.Default.GetBytes(message));
            }
