    [JsonConverter(typeof(PaymentDTOConverter))]
    public class PaymentDTO
    {
        static Dictionary<string, Type> namesToTransactions;
        static Dictionary<Type, string> transactionsToNames = new Dictionary<Type, string>
        {
            { typeof(SaleDTO), "sale" },
            { typeof(OrderDTO), "order" },
        };
        static PaymentDTO()
        {
            namesToTransactions = transactionsToNames.ToDictionary(p => p.Value, p => p.Key);
        }
        public static string GetTransactionDTOTypeName<TTransactionDTO>() where TTransactionDTO : TransactionDTO
        {
            string name;
            if (transactionsToNames.TryGetValue(typeof(TTransactionDTO), out name))
                return name;
            return null;
        }
        public static Type GetTransactionDTOType(string name)
        {
            Type type;
            if (namesToTransactions.TryGetValue(name, out type))
                return type;
            return null;
        }
        public int Id { get; set; }
        public string type { get; set; }
        [JsonProperty("transactions")]
        public IEnumerable<TransactionDTO> Transactions { get; set; }
    }
