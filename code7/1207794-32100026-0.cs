    public class Configuration
    {
        public ConfigurationTransaction this[string transaction]
        {
            get
            {
                return Transactions.First(tran => tran.Type == transaction);
            }
            set
            {
                int index = Transactions.FindIndex(tran => tran.Type == value.Type);
                if (index >= 0)
                    Transactions[index] = value;
                else
                    Transactions.Add(value);
            }
        }
        public List<ConfigurationTransaction> Transactions { get; set; }
    }
    public class ConfigurationTransaction
    {
        [XmlAttribute()]
        public string Type { get; set; }
    }
