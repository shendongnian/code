    using System;
    using System.Text;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;
    class SendReceive
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
    
                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);
    			
    			 var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
    
                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
    			
    			channel.BasicConsume(queue: "hello",
    			noAck: true,
    			consumer: consumer);
    
            }
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
