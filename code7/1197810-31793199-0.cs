    public class netConsumer
    {
        public string message;
        public KafkaOptions options = new KafkaOptions(new Uri("http://rqdsn0c.bnymellon.net:9092"), new Uri("http://rqdsn0c.bnymellon.net:9092"), new Uri("http://rqdsn0c.bnymellon.net:9092"))
        {
            Log = new ConsoleLog()
        };
        public BrokerRouter router = new BrokerRouter(options);
        public string consume()
        {
            var consumer = new Consumer(new ConsumerOptions("TestHarness3", router));
            foreach (var data in consumer.Consume())
            {
                Console.WriteLine("Response: P{0},O{1} : {2}", data.Meta.PartitionId, data.Meta.Offset, data.Value);
                var utf8 = Encoding.UTF8;
                message += utf8.GetString(data.Value, 0, data.Value.Length);
                ExcelWorksheet.writeToExcel(message);
            }
            return message;
        }
    }
