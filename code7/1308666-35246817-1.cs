        public class QueueCommand
        {
            public QueueCommand()
            {
                Id = Guid.NewGuid();
            }
            public Guid Id { get; set; }
            public SerialOperation Operation { get; set; }
            public int BytesToRead { get; set; }
            public byte[] BytesToWrite { get; set; }
        }
