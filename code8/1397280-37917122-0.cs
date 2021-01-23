    class MailMessageQueue : IDisposable {
        private IConnection _connection;
        private IModel _channel;
        public void Start() {
            _connection = _connectionFactory.CreateConnection();
            _channel = connection.CreateModel();
            // configuring queue etc....
            options.DeclareConsumer(queueName, MessageReceived);
        }
        public void Stop() {
            _channel.Dispose();
            _connection.Dispose();
        }
        public void Dispose() {
            Stop();
        }
    }
