    public class Configuration
    {
        public ConfigurationTransaction this[string transactionName]
        {
            get
            {
                return Transactions.First(tran => tran.TransactionName == transactionName).ConfigurationTransaction;
            }
            set
            {
                int index = Transactions.FindIndex(tran => tran.TransactionName == transactionName);
                if (index >= 0)
                    Transactions[index] = new PairHelper { TransactionName = transactionName, ConfigurationTransaction = value };
                else
                    Transactions.Add(new PairHelper { TransactionName = transactionName, ConfigurationTransaction = value });
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public List<PairHelper> Transactions { get; set; }
    }
    public class ConfigurationTransaction
    {
        [XmlAttribute()]
        public string Type { get; set; }
    }
    public class PairHelper
    {
        public string TransactionName { get; set; }
        public ConfigurationTransaction ConfigurationTransaction { get; set; }
    }
