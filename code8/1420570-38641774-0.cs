        public class CommandMessage
        {
            public Guid CorrelationId { get; set; }
        }
        static void Main(string[] args)
        {
            var commandMessage = new CommandMessage { CorrelationId = Guid.NewGuid() };
            var json = JsonConvert.SerializeObject(commandMessage);
            var myCommandMessage =  JsonConvert.DeserializeObject<CommandMessage>(json);
        }
    
