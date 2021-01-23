    class Program
    {
        static void Main(string[] args)
        {
            var ser = new XmlSerializer(typeof(Model));
            using (var fs = new FileStream("source.xml", FileMode.Open))
            {
                var obj = (Model) ser.Deserialize(fs);
                Console.WriteLine(obj.Transactions[0].Messages[0].In.ProcessCode);
            }
        }
    }
    
    public class Model
    {
        [XmlElement("Transaction")]
        public List<Transaction> Transactions;
    }
    public class Transaction
    {
        [XmlElement("Message")]
        public List<Message> Messages;
    }
    public class Message
    {
        public MessageType In { get; set; }
        public MessageType Out { get; set; }
    }
    public class MessageType
    {
        public int ChannelType { get; set; }
        public int TransactionType { get; set; }
        private int processCodeInt;
        public ProcessCode ProcessCode
        {
            get { return (ProcessCode) processCodeInt; }
            set { processCodeInt = (int) value; }
        }
        public bool IsExpired { get; set; }
    }
    public enum ProcessCode
    {
        Balance
    }
