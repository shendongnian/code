    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Framing.v0_9_1;
    
    namespace RabbitMQReprocessDeadLetter
    {
        public class RabbitReprocessor
        {
            private readonly IModel _model;
            private readonly string _deadLetterQueueName;
            private const ushort FetchSize = 10;
            private const string ConsumerName = "DeadLetterReprocessor";
    
            public RabbitReprocessor(IConnection rabbitConnection, string deadLetterQueueName)
            {
                _deadLetterQueueName = deadLetterQueueName;
                _model = rabbitConnection.CreateModel();
            }
    
            public void StartConsuming(CancellationTokenSource cancellationTokenSource = null)
            {
                // Configure the Quality of service for the model. Below is how what each setting means.
                // BasicQos(0="Dont send me a new message untill I’ve finshed",  _fetchSize = "Send me N messages at a time", false ="Apply to this Model only")
                _model.BasicQos(0, FetchSize, false);
    
                var queueingBasicConsumer = new QueueingBasicConsumer(_model);
                _model.BasicConsume(_deadLetterQueueName, false, ConsumerName, queueingBasicConsumer);
    
                while (true)
                {
                    if (cancellationTokenSource != null && cancellationTokenSource.IsCancellationRequested)
                    {
                        return;
                    }
    
                    var e = queueingBasicConsumer.Queue.Dequeue(); // blocking call
                    var deathProperties = (List<object>) e.BasicProperties.Headers["x-death"];
                    var prop = (Dictionary<string, object>)deathProperties.Single();
                    var queueAsByteArray = (byte[])prop["queue"];
                    var queueName = queueAsByteArray.ConvertToString();
                    var data = e.Body;
                    try
                    {
                        Console.WriteLine("{0} => {1}", queueName, data.Deserialize<long>());
                    }
                    // ReSharper disable once EmptyGeneralCatchClause
                    catch { }
                    SendMessageToQueue(queueName, data);
                    _model.BasicAck(e.DeliveryTag, false);
                }
            }
    
            /// <summary>
            /// delivery the message directly into the queue from which it came.
            /// 
            /// You may want to put it back into an exchange instead of a queue.
            /// </summary>
            private void SendMessageToQueue(string queueName, byte[] messageBytes)
            {
                const string exchangeName = "";
                if (string.IsNullOrEmpty(queueName))
                {
                    throw new ArgumentNullException("queueName");
                }
                if (messageBytes == null)
                {
                    throw new ArgumentNullException("messageBytes");
                }
                var basicProperties = new BasicProperties
                {
                    DeliveryMode = 2//2 = durable
                };
                _model.BasicPublish(exchangeName, queueName, basicProperties, messageBytes);
            }
        }
    }
